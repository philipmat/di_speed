using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Locators;
using Dummies;

namespace Main_4
{
	class Program
	{
		static int RUNS;
		static int LOOPS;
		static string PAYLOAD = "singleton";
		static Dictionary<string, Func<IEnumerable<ILocator>>> PAYLOADS = new Dictionary<string,Func<IEnumerable<ILocator>>> {
			{ "singleton" , Program_Singleton},
			{ "transient" , Program_New},
		};
		static void Main(string[] args) {
			try {
				ParseArgs(args);
			} catch (FormatException fex) {
				Console.WriteLine(fex.Message);
				Console.WriteLine("Usage: Main [r=10] [l=10,000] [singleton|transient|singleton_loaded|transient_loaded]");
				return;
			}


			var runners = PAYLOADS[PAYLOAD]();

			RunLoop(runners);
		}

		private static void RunLoop(IEnumerable<ILocator> runners) {
			for (var l=1; l <= RUNS; l++) {
				p().BeginGroup(l.ToString());
				foreach (var r in runners) {
					SimpleDummy.COUNTER = 0;
					var k = new PerfCounter(r.Name); k.Begin();

					for (var i = 0; i < LOOPS; i++) {
						r.Run();
					}

					k.End(); p().Collect(k);
					if (SimpleDummy.COUNTER != LOOPS)
						Console.WriteLine("{0} cheated and only created {1} objects instead of {2}.", r.Name, SimpleDummy.COUNTER, LOOPS);
				}
				p().EndGroup();
			}
			p().Flush();
		}

		static IEnumerable<ILocator> Program_Singleton() {
			var runners = new ILocator[] {
				new AutofacRunner(),
				new CastleWindsorRunner(),
				new NinjectRunner(),
				new SpringRunner(),
				new StructureMapRunner(),
				new UnityRunner(),
			};
			foreach (var r in runners) {
				r.WarmUp_Singleton();
			}
			SimpleDummy.BLOW_UP_IF_COUNTER_LARGER_THAN = 1;
			return runners;
		}

		static IEnumerable<ILocator> Program_New() {
			var runners = new ILocator[] {
				new AutofacRunner(),
				new CastleWindsorRunner(),
				new NinjectRunner(),
				new SpringRunner(),
				new StructureMapRunner(),
				new UnityRunner(),
			};
			foreach (var r in runners) {
				r.WarmUp_NewEveryTime();
			}
			SimpleDummy.BLOW_UP_IF_COUNTER_LARGER_THAN = LOOPS;
			return runners;
		}

		

		private static void ParseArgs(string[] args) {
			LOOPS = int.Parse("10,000", System.Globalization.NumberStyles.AllowThousands);
			RUNS = 5;
			foreach (string arg in args) {
				switch (arg.ToLower()) {
					case "singleton":
					case "transient" :
						PAYLOAD = arg.ToLower();
						break;
					default:
						if (arg.StartsWith("l=", StringComparison.CurrentCultureIgnoreCase)) {
							int i;
							if (!int.TryParse(arg.Substring(2), System.Globalization.NumberStyles.AllowThousands, null, out i)) {
								throw new FormatException(string.Format("{0} doesn't seem to be a number.", args));
							}
							LOOPS = i;
						}
						if (arg.StartsWith("r=", StringComparison.CurrentCultureIgnoreCase)) {
							int i;
							if (!int.TryParse(arg.Substring(2), System.Globalization.NumberStyles.AllowThousands, null, out i)) {
								throw new FormatException(string.Format("{0} doesn't seem to be a number.", arg));
							}
							RUNS = i;
						}
						break;
				}
			}
			Console.WriteLine("Doing {0} runs of {1} DI loops each. Program: {2}.", RUNS, LOOPS, PAYLOAD);
		}

		static Printer _p;
		private static Printer p() {
			if (_p != null) return _p;
			if (Debugger.IsAttached) _p = new ConsolePrinter();
			else _p = new AveragingPrinter();
			return _p;
		}
	}
}
