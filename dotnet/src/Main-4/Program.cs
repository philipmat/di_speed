using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Main_4.Locators;

namespace Main_4
{
	class Program
	{
		static readonly int RUNS = int.Parse("10,000", System.Globalization.NumberStyles.AllowThousands); // it's 2011: the compiler should understand 1_000_000.
		const int LOOPS = 5;
		static void Main(string[] args) {
			var runners = new ILocator[] {
				new AutofacRunner(),
				new CastleWindsorRunner(),
				new NinjectRunner(),
				new SpringRunner(),
				new StructureMapRunner(),
				new UnityRunner(),
			};
			foreach (var r in runners) {
				r.WarmUp();
			}
			SimpleDummy.BLOW_UP_IF_IN_CONSTRUCTOR = false;

			var chron = new Stopwatch();
			for (var l=1; l <= LOOPS; l++) {
				Console.WriteLine("LOOP {0}: START", l);
				foreach (var r in runners) {
					long memStart = GC.GetTotalMemory(true);
					chron.Restart();
					for (var i = 0; i < RUNS; i++) {
						r.Run();
					}
					chron.Stop();
					long memEndUncollected = GC.GetTotalMemory(false);
					long memEnd = GC.GetTotalMemory(true);
					Console.WriteLine("{0,-15}: {1,6:n0}ms ({2,10:n0} ticks). Mem: {3,4:n0}B, AC {4,4}B.",
						r.Name, chron.ElapsedMilliseconds, chron.ElapsedTicks, memEndUncollected - memStart, memEnd - memStart);
				}
				Console.WriteLine("LOOP {0}: END.", l);
			}
			if (Debugger.IsAttached) {
				Console.Write("Press any key to quit...");
				Console.ReadKey();
			}
		}
	}
}
