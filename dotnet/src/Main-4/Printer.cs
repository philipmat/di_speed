using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Main_4
{
	class Printer
	{
		protected List<KeyValuePair<string, List<PerfCounter>>> collection = new List<KeyValuePair<string, List<PerfCounter>>>();

		public virtual void BeginGroup(string groupName = null) {
			var name = groupName ?? collection.Count.ToString();
			collection.Add(new KeyValuePair<string, List<PerfCounter>>(name, new List<PerfCounter>()));
		}

		public virtual void Collect(PerfCounter aCounter) {
			collection.Last().Value.Add(aCounter);
		}

		public virtual void EndGroup() {
		}

		public virtual void Flush() {
		}

		public bool ShowMemory { get; set; }
	}

	class ConsolePrinter : Printer
	{
		public override void BeginGroup(string groupName = null) {
			base.BeginGroup(groupName);
			Console.WriteLine("GROUP {0}: START.", collection.Last().Key);
		}

		public override void Collect(PerfCounter aCounter) {
			base.Collect(aCounter);
			Console.WriteLine("{0,-15}: {1,6:n0}ms ({2,10:n0} ticks)." + (ShowMemory ?" Mem: {3,4:n0}B, AC {4,4}B." : ""),
									aCounter.Name, aCounter.ElapsedMilliseconds, aCounter.ElapsedTicks, aCounter.UncollectedMemory, aCounter.CollectedMemory);
		}

		public override void EndGroup() {
			base.EndGroup();
			Console.WriteLine("GROUP {0}: End.{1}", collection.Last().Key, Environment.NewLine);
		}

		public override void Flush() {
			base.Flush();
			Console.Write("Press any key to quit...");
			Console.ReadKey();
		}
	}

	class AveragingPrinter : Printer
	{
		public override void Flush() {
			base.Flush();
			int runs = collection.Count;

			List<KeyValuePair<string, AvgInfo>> avg = new List<KeyValuePair<string, AvgInfo>>();
			var counters = from pc in collection.SelectMany(kvp => kvp.Value.Select(pc => pc))
						   group pc by pc.Name into c
						   orderby c.Key
						   select new AvgInfo {
							   Name = c.Key,
							   EllapsedMilliseconds = (long) c.Average(x => x.ElapsedMilliseconds),
							   EllapsedTicks = (long) c.Average(x => x.ElapsedTicks),
							   Memory = (long) c.Average(x => x.UncollectedMemory),
							   CollectedMemory = (long) c.Average(x => x.CollectedMemory)
						   };
			int max_name = counters.Max(x => x.Name.Length) + 1;
			int max_ms = counters.Max(x => x.EllapsedMilliseconds.ToString("n0").Length) + 1;
			int max_mu = counters.Max(x => x.Memory.ToString("n0").Length) + 1;
			int max_mc = counters.Max(x => x.CollectedMemory.ToString("n0").Length) + 1;

			string f = "{0,-" + max_name + "}: {1," + max_ms + ":n0} ms.";
			if (ShowMemory) f += " Mem: {2," + max_mu + ":n0}B b/c, {3," + max_mc + ":n0}B a/c.";
			foreach(var c in counters) {
				Console.WriteLine(string.Format(f, c.Name, c.EllapsedMilliseconds, c.Memory, c.CollectedMemory));
			}
		}


		private class AvgInfo
		{
			public string Name;
			public long EllapsedMilliseconds;
			public long EllapsedTicks;
			public long Memory;
			public long CollectedMemory;
		}
	}
}
