using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Main_4
{
	[System.Diagnostics.DebuggerDisplay("{ElapsedMilliseconds}ms", Name="{Name}")]
	class PerfCounter
	{
		public PerfCounter(string forName) {
			Name = forName;
		}
		
		public string Name { get; private set; }
		public long ElapsedMilliseconds { get; private set; }
		public long ElapsedTicks { get; private set; }
		public long CollectedMemory { get; private set; }
		public long UncollectedMemory { get; private set; }

		public void Begin() {
			memStart = GC.GetTotalMemory(true);
			watch.Restart();
		}

		public void End() {
			watch.Stop();
			ElapsedMilliseconds = watch.ElapsedMilliseconds;
			ElapsedTicks = watch.ElapsedTicks;
			memUncollectedEnd = GC.GetTotalMemory(false);
			memEnd = GC.GetTotalMemory(true);
			CollectedMemory = memEnd - memStart;
			UncollectedMemory = memUncollectedEnd - memStart;
		}

		private Stopwatch watch = new Stopwatch();
		private long memStart, memEnd, memUncollectedEnd;
	}
}
