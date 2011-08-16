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
		const int INTERFACE_INCREMENT = 50;

		static int RUNS;
		static int LOOPS;
		static string PAYLOAD = "singleton_loaded_ex";
		static Type INVALID = typeof(InvalidOperationException); // don't put a type with unambiguous constructor(s) - Unity will create it even if not registered

		static Dictionary<string, RunConfig> PAYLOADS = new Dictionary<string, RunConfig> {
			// { "singleton" , new RunConfig { GetRunners = Program_Singleton, PreLoops =  PreLoops, PostLoops = PostLoopsSingleton, Run = (r, i, runState, loopState) => r.Run() }},
			// { "transient" , new RunConfig { GetRunners = Program_New, PreLoops =  PreLoops, PostLoops = PostLoopsTransient, Run = (r, i, runState, loopState) => r.Run() }},
			{ "singleton_loaded" , new RunConfig { GetRunners = Program_Singleton_Loaded, PreRuns = PreRunLoaded , Run = RunInvalidClassRunner }},
			// { "transient_loaded" , new RunConfig { GetRunners = Program_New_Loaded, PreRuns = PreRunLoaded , Run = RunLoadedRunner }},
			{ "singleton_loaded_ex" , new RunConfig { GetRunners = Program_Singleton_Loaded_Ex, PreRuns = PreRunLoaded , Run = RunInvalidClassRunner }},
			{ "singleton_loaded_opt" , new RunConfig { GetRunners = Program_Singleton_Loaded, PreRuns = PreRunLoaded , Run = RunInvalidClassRunner }},
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
			if(Debugger.IsAttached) Console.ReadLine();
		}

		private static void RunLoop(RunConfig runConfig) {
			object preRunState = null;
			object preLoopState = null;
			for (var ifs = 1; ifs < LOADED_INTERFACES; ifs = ifs + INTERFACE_INCREMENT) {
				var runners = runConfig.GetRunners(ifs);
				if (runConfig.PreRuns != null) preRunState = runConfig.PreRuns();
				Action<ILocatorMultiVar, int, object, object> run = runConfig.Run;
				Func<ILocatorMultiVar, int, object, object> preLoopRun = runConfig.PreLoops;
				Action<ILocatorMultiVar, object, object> postLoopRun = runConfig.PostLoops;
				p().BeginGroup(ifs.ToString("0000"), null);

				for (var l=0; l < RUNS; l++) {
					p().BeginGroup((l + 1).ToString());
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
				p().EndGroup();
			}
			p().Flush();
			if (runConfig.PostRuns != null) runConfig.PostRuns(preRunState);
		}


		private static object PreLoops(ILocatorMultiVar locator, int runNumber, object preRunState) {
			SimpleDummy.COUNTER = 0; // guard to ensure the containers are honest - only works in unloaded mode
			return runNumber;
		}

		private static void PostLoopsTransient(ILocatorMultiVar l, object preRunState, object preLoopState) {
			// guard to ensure the containers are honest - only works in unloaded mode
			if (SimpleDummy.COUNTER != LOOPS)
				Console.WriteLine("{0} cheated and only created {1} objects instead of {2}.", l.Name, SimpleDummy.COUNTER, LOOPS);
		}

		private static void PostLoopsSingleton(ILocatorMultiVar l, object preRunState, object preLoopState) {
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

		private static void RunLoadedRunner(ILocatorMultiVar l, int index, object preRunState, object preLoopsState) {
			var kvp = ((KeyValuePair<Type, string>[]) preRunState)[index];
			((ILocatorMultiVar) l).Run(kvp.Key, kvp.Value);
		}

		private static void RunInvalidClassRunner(ILocatorMultiVar l, int index, object preRunState, object preLoopsState) {
			((ILocatorMultiVar) l).Run(INVALID, "5");
		}

		static IEnumerable<ILocatorMultiVar> Program_Singleton_Loaded(int load) {
			var runners = new ILocatorMultiVar[] {
				new VariableLoadAutofacRunner(),
				new VariableLoadUnityRunner(),
			};
			foreach (var r in runners) {
				r.WarmUp_Singleton(load);
			}
			return runners;
		}

		static IEnumerable<ILocatorMultiVar> Program_New_Loaded(int load) {
			var runners = new ILocatorMultiVar[] {
				new VariableLoadAutofacRunner(),
				new VariableLoadUnityRunner(),
			};
			foreach (var r in runners) {
				r.WarmUp_NewEveryTime(load);
			}
			return runners;
		}

		static IEnumerable<ILocatorMultiVar> Program_Singleton_Loaded_Ex(int load) {
			var runners = new ILocatorMultiVar[] {
				new VariableLoadAutofacRunner(false),
				new VariableLoadUnityRunner(false),
			};
			foreach (var r in runners) {
				r.WarmUp_Singleton(load);
			}
			return runners;
		}

		

		private static void ParseArgs(string[] args) {
			LOOPS = int.Parse("1000", System.Globalization.NumberStyles.AllowThousands);
			RUNS = 2;
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

		static DoubleWidePrinter _p;
		private static DoubleWidePrinter p() {
			if (_p != null) return _p;
			_p = new TableAveragingPrinter();
			return _p;
		}

		class RunConfig
		{
			public Func<int, IEnumerable<ILocatorMultiVar>> GetRunners { get; set; }
			/// <summary>
			/// Happens before the runs. Returns a "state" object which is passed into the Run along with the loop index
			/// </summary>
			public Func<object> PreRuns { get; set; }
			/// <summary>
			/// Happens before each locator's loops passing in the run number. Can return yet another state object.
			/// </summary>
			public Func<ILocatorMultiVar, int, object, object> PreLoops { get; set; }
			/// <summary>
			/// The actual run loop. 1st object is the PreRuns state, second is the PreLoops state
			/// </summary>
			public Action<ILocatorMultiVar, int, object, object> Run { get; set; }
			/// <summary>
			/// Called after the locator's loops are done. 1st object is the PreRuns state, second is the PreLoops state
			/// </summary>
			public Action<ILocatorMultiVar, object, object> PostLoops { get; set; }
			/// <summary>
			/// Happens after the runs. Object is the PreRuns state.
			/// </summary>
			public Action<object> PostRuns { get; set; }
		}
	}
}
