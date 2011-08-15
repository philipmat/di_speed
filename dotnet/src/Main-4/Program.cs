using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Locators;
using Dummies;
using System.Configuration;

namespace Main_4
{
	class Program
	{
		const int LOADED_INTERFACES = 222;
		const int CLASSES_PER_INTERFACE = 3;

		static int RUNS;
		static int LOOPS;
		static string PAYLOAD = "singleton_loaded";
		static Dictionary<string, RunConfig> PAYLOADS = new Dictionary<string, RunConfig> {
			// { "singleton" , new RunConfig { GetRunners = Program_Singleton, PreLoops =  PreLoops, PostLoops = PostLoopsSingleton, Run = (r, i, runState, loopState) => r.Run() }},
			// { "transient" , new RunConfig { GetRunners = Program_New, PreLoops =  PreLoops, PostLoops = PostLoopsTransient, Run = (r, i, runState, loopState) => r.Run() }},
			{ "singleton_loaded" , new RunConfig { GetRunners = Program_Singleton_Loaded, PreRuns = PreRunLoaded , Run = RunLoadedRunner }},
			// { "transient_loaded" , new RunConfig { GetRunners = Program_New_Loaded, PreRuns = PreRunLoaded , Run = RunLoadedRunner }},
			{ "singleton_loaded_ex" , new RunConfig { GetRunners = Program_Singleton_Loaded_Ex, PreRuns = PreRunLoaded , Run = RunLoadedRunner }},
		};
		static void Main(string[] args) {
			try {
				ParseArgs(args);
			} catch (FormatException fex) {
				Console.WriteLine(fex.Message);
				Console.WriteLine("Usage: Main [r=10] [l=10,000] [" + string.Join("|", PAYLOADS.Keys) + "]");
				return;
			}


			var runConfig = PAYLOADS[PAYLOAD];

			RunLoop(runConfig);
		}

		private static void RunLoop(RunConfig runConfig) {
			var runners = runConfig.GetRunners();
			object preRunState = null;
			object preLoopState = null;
			if (runConfig.PreRuns != null) preRunState = runConfig.PreRuns();
			Action<ILocator, int, object, object> run = runConfig.Run;
			Func<ILocator, int, object, object> preLoopRun = runConfig.PreLoops;
			Action<ILocator, object, object> postLoopRun = runConfig.PostLoops;

			for (var l=0; l < RUNS; l++) {
				p().BeginGroup((l+1).ToString());
				foreach (var r in runners) {
					if (preLoopRun != null) preLoopState = preLoopRun(r, l, preRunState);

					var k = new PerfCounter(r.Name); k.Begin();

					for (var i = 0; i < LOOPS; i++) {
						run(r, i, preRunState, preLoopState);
					}

					k.End(); p().Collect(k);
					if (postLoopRun != null) postLoopRun(r, preRunState, preLoopState);
				}
				p().EndGroup();
			}
			p().Flush();
			if (runConfig.PostRuns != null) runConfig.PostRuns(preRunState);
		}


		private static object PreLoops(ILocator locator, int runNumber, object preRunState) {
			SimpleDummy.COUNTER = 0; // guard to ensure the containers are honest - only works in unloaded mode
			return runNumber;
		}

		private static void PostLoopsTransient(ILocator l, object preRunState, object preLoopState) {
			// guard to ensure the containers are honest - only works in unloaded mode
			if (SimpleDummy.COUNTER != LOOPS)
				Console.WriteLine("{0} cheated and only created {1} objects instead of {2}.", l.Name, SimpleDummy.COUNTER, LOOPS);
		}

		private static void PostLoopsSingleton(ILocator l, object preRunState, object preLoopState) {
			// guard to ensure the containers are honest - only works in unloaded mode
			int expected = (int) preLoopState == 0 ? 1 : 0;  // only create an instance on the first load
			if (SimpleDummy.COUNTER != expected)
				Console.WriteLine("{0} expected to have created {2} objects instead of {1}.", l.Name, SimpleDummy.COUNTER, expected);
		}


		private static object PreRunLoaded() {
			KeyValuePair<Type, string>[] types = new KeyValuePair<Type, string>[LOOPS];
			var rnd = new Random();
			for (var i = 0; i < LOOPS; i++) {
				Type t = Type.GetType(string.Format("Dummies.IDummy{0}", rnd.Next(LOADED_INTERFACES)));
				var name = rnd.Next(3).ToString();
				types[i] = new KeyValuePair<Type, string>(t, name);
			}
			return types;
		}

		private static void RunLoadedRunner(ILocator l, int index, object preRunState, object preLoopsState) {
			var kvp = ((KeyValuePair<Type, string>[]) preRunState)[index];
			((ILocatorMulti) l).Run(kvp.Key, kvp.Value);
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


		static IEnumerable<ILocator> Program_Singleton_Loaded() {
			var runners = new ILocator[] {
				//new LoadedAutofacRunner(),
				//new LoadedCastleWindsorRunner(),
				//new LoadedNinjectRunner(),
				//new LoadedSpringRunner(),
				//new LoadedStructureMapRunner(),
				new LoadedUnityRunner(),
			};
			foreach (var r in runners) {
				r.WarmUp_Singleton();
			}
			return runners;
		}

		static IEnumerable<ILocator> Program_New_Loaded() {
			var runners = new ILocator[] {
				new LoadedAutofacRunner(),
				new LoadedCastleWindsorRunner(),
				new LoadedNinjectRunner(),
				new LoadedSpringRunner(),
				new LoadedStructureMapRunner(),
				new LoadedUnityRunner(),
			};
			foreach (var r in runners) {
				r.WarmUp_NewEveryTime();
			}
			return runners;
		}

		static IEnumerable<ILocator> Program_Singleton_Loaded_Ex() {
			var runners = new ILocator[] {
				//new LoadedAutofacRunner(),
				//new LoadedCastleWindsorRunner(),
				//new LoadedNinjectRunner(),
				//new LoadedSpringRunner(),
				//new LoadedStructureMapRunner(),
				new LoadedUnityRunner(false),
			};
			foreach (var r in runners) {
				r.WarmUp_Singleton();
			}
			return runners;
		}

		

		private static void ParseArgs(string[] args) {
			LOOPS = int.Parse("10,000", System.Globalization.NumberStyles.AllowThousands);
			RUNS = 5;
			foreach (string arg in args) {
				switch (arg.ToLower()) {
					case "singleton":
					case "transient" :
					case "singleton_loaded":
					case "singleton_loaded_ex":
					case "transient_loaded":
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
			bool showMemory = false;
			if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["show_memory"]))
				bool.TryParse(ConfigurationManager.AppSettings["show_memory"], out showMemory);

			if (Debugger.IsAttached) _p = new ConsolePrinter();
			else _p = new AveragingPrinter();
			_p.ShowMemory = showMemory;
			return _p;
		}

		class RunConfig
		{
			public Func<IEnumerable<ILocator>> GetRunners { get; set; }
			/// <summary>
			/// Happens before the runs. Returns a "state" object which is passed into the Run along with the loop index
			/// </summary>
			public Func<object> PreRuns { get; set; }
			/// <summary>
			/// Happens before each locator's loops passing in the run number. Can return yet another state object.
			/// </summary>
			public Func<ILocator, int, object, object> PreLoops { get; set; }
			/// <summary>
			/// The actual run loop. 1st object is the PreRuns state, second is the PreLoops state
			/// </summary>
			public Action<ILocator, int, object, object> Run { get; set; }
			/// <summary>
			/// Called after the locator's loops are done. 1st object is the PreRuns state, second is the PreLoops state
			/// </summary>
			public Action<ILocator, object, object> PostLoops { get; set; }
			/// <summary>
			/// Happens after the runs. Object is the PreRuns state.
			/// </summary>
			public Action<object> PostRuns { get; set; }
		}
	}
}
