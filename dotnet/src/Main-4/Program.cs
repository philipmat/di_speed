using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Main_4
{
	class Program
	{
		static readonly int RUNS = 1000000; // it's 2011: the compiler should understand 1_000_000.
		static void Main(string[] args) {
			var runners = new IDependencyInjectorRunner[] {
				new UnityRunner()
			};
			foreach (var r in runners) {
				r.WarmUp();
			}

			var chron = new Stopwatch();
			foreach (var r in runners) {
				chron.Restart();
				r.Run(RUNS);
				chron.Stop();
				Console.WriteLine("{0}: {1:n0}ms ({2:n0} ticks).", r.Name, chron.ElapsedMilliseconds, chron.ElapsedTicks);
			}
			if (Debugger.IsAttached) {
				Console.Write("Press any key to quit...");
				Console.ReadKey();
			}
		}
	}
}
