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
		static string PAYLOAD = "one";
		static Dictionary<string, Action<IEnumerable<ILocator>>> PAYLOADS = new Dictionary<string,Action<IEnumerable<ILocator>>> {
			{ "one" , Program_One},
		};
		static void Main(string[] args) {
			try {
				ParseArgs(args);
			} catch (FormatException fex) {
				Console.WriteLine(fex.Message);
				return;
			}

			var runners = new ILocator[] {
				new AutofacRunner(),
				new CastleWindsorRunner(),
				new NinjectRunner(),
				new SpringRunner(),
				new StructureMapRunner(),
				new UnityRunner(),
			};

			PAYLOADS[PAYLOAD](runners);

			RunLoop(runners);
		}

		private static void RunLoop(ILocator[] runners) {
			for (var l=1; l <= RUNS; l++) {
				p().BeginGroup(l.ToString());
				foreach (var r in runners) {
					var k = new PerfCounter(r.Name); k.Begin();

					for (var i = 0; i < LOOPS; i++) {
						r.Run();
					}

					k.End(); p().Collect(k);
				}
				p().EndGroup();
			}
			p().Flush();
		}

		static void Program_One(IEnumerable<ILocator> runners) {
			foreach (var r in runners) {
				r.WarmUp();
			}
			SimpleDummy.BLOW_UP_IF_IN_CONSTRUCTOR = false;
		}


		private static void ParseArgs(string[] args) {
			LOOPS = int.Parse("10,000", System.Globalization.NumberStyles.AllowThousands);
			RUNS = 5;
			switch (args.Length) {
				case 0:
					break;
				case 1: {
						int i;
						if (!int.TryParse(args[0], out i)) {
							throw new FormatException(string.Format("{0} doesn't seem to be a number.", args[0]));
						}
						LOOPS = i;
					}
					break;
				case 2:
				default: {
						int i, j;
						if (!int.TryParse(args[0], out i)) {
							throw new FormatException(string.Format("{0} doesn't seem to be a number.", args[0]));
						}
						if (!int.TryParse(args[1], out j)) {
							throw new FormatException(string.Format("{0} doesn't seem to be a number.", args[1]));
						}
						RUNS = Math.Min(i, j);
						LOOPS = Math.Max(i, j);
					}
					break;
			}

			Console.WriteLine("Doing {0} runs of {1} DI loops each.", RUNS, LOOPS);
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
