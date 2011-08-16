using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Main_4
{
	class Printer
	{
		protected List<Item> collection = new List<Item>();

		public virtual void BeginGroup(string groupName = null) {
			var name = groupName ?? collection.Count.ToString();
			collection.Add(new Item(name, new List<PerfCounter>()));
		}

		public virtual void Collect(PerfCounter aCounter) {
			collection.Last().Item2.Add(aCounter);
		}

		public virtual void EndGroup() {
		}

		public virtual void Flush() {
		}


		public bool ShowMemory { get; set; }

		public class MutableTuple<T1, T2> {
			public MutableTuple (T1 item1, T2 item2) {
				Item1 = item1;
				Item2 = item2;
			}
			public T1 Item1 { get ; set; }
			public T2 Item2 { get ;set; }
		}

		public class MutableTuple<T1, T2, T3> : MutableTuple<T1, T2> {
			public MutableTuple (T1 item1, T2 item2, T3 item3) :base(item1, item2) {
				Item3 = item3;
			}
			public T3 Item3 { get ; set; }
		}
		
		public class Item : MutableTuple<string, List<PerfCounter>>  {
			public Item (string name, List<PerfCounter> counters) : base(name, counters) {}

		}
	}

	class ConsolePrinter : Printer
	{
		public override void BeginGroup(string groupName = null) {
			base.BeginGroup(groupName);
			Console.WriteLine("GROUP {0}: START.", collection.Last().Item1);
		}

		public override void Collect(PerfCounter aCounter) {
			base.Collect(aCounter);
			Console.WriteLine("{0,-15}: {1,6:n0}ms ({2,10:n0} ticks)." + (ShowMemory ? " Mem: {3,4:n0}B, AC {4,4}B." : ""),
									aCounter.Name, aCounter.ElapsedMilliseconds, aCounter.ElapsedTicks, aCounter.UncollectedMemory, aCounter.CollectedMemory);
		}

		public override void EndGroup() {
			base.EndGroup();
			Console.WriteLine("GROUP {0}: End.{1}", collection.Last().Item1, Environment.NewLine);
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
			var counters = from pc in collection.SelectMany(kvp => kvp.Item2.Select(pc => pc))
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


	class DoubleWidePrinter : Printer
	{
		protected new List<MutableTuple<string, string, List<PerfCounter>>> collection = new List<MutableTuple<string, string, List<PerfCounter>>>();
		private string lastCollection = null;

		public override void BeginGroup(string groupName = null) {
			if (lastCollection == null) throw new InvalidOperationException("There is no current master group defined.");
			var tuple = collection.First(k => k.Item1.Equals(lastCollection, StringComparison.InvariantCultureIgnoreCase));
			if (string.IsNullOrEmpty(tuple.Item2)) tuple.Item2 = groupName;
			else
				collection.Add(new MutableTuple<string, string, List<PerfCounter>>(lastCollection, groupName, new List<PerfCounter>()));
		}

		public void BeginGroup(string name1, string name2) {
			collection.Add(new MutableTuple<string, string, List<PerfCounter>>(name1, name2, new List<PerfCounter>()));
			lastCollection = name1;
		}

		public override void Collect(PerfCounter aCounter) {
			collection.Last().Item3.Add(aCounter);
		}
	}

	class TableAveragingPrinter : DoubleWidePrinter
	{

		public override void Flush() {
			base.Flush();
			IEnumerable<string> lines = collection.Select(x => x.Item1).Distinct();
			IEnumerable<string> columns = collection.SelectMany(x => x.Item3).Select(pcs => pcs.Name).Distinct().OrderBy(s => s);
			List<Tuple<string, string, AvgInfo>> averages = new List<Tuple<string, string, AvgInfo>>();

			var maxColWidth = columns.Select(c => c.Length).Max();
			var maxNameWidth = lines.Select(c => c.Length).Max();
			int runs = collection.Count;

			List<KeyValuePair<string, AvgInfo>> avg = new List<KeyValuePair<string, AvgInfo>>();
			var counters = from x in collection
						   group x by x.Item1 into row
						   orderby row.Key
						   select new {
							   Line = row.Key,
							   Cells = row.SelectMany(x => x.Item3).GroupBy(x => x.Name).Select( x => 
								   new { Column = x.Key, 
									     Info = new AvgInfo {
										   Name = x.Key,
										   EllapsedMilliseconds = (long) x.Average(pc => pc.ElapsedMilliseconds),
										   EllapsedTicks = (long) x.Average(pc => pc.ElapsedTicks),
										   Memory = (long) x.Average(pc => pc.UncollectedMemory),
										   CollectedMemory = (long) x.Average(pc => pc.CollectedMemory)
									   }
								   })
						   };
			// int max_ms = counters.Max(x => x.Info.EllapsedMilliseconds.ToString("n0").Length) + 1;
			// int max_mu = counters.Max(x => x.Info.Memory.ToString("n0").Length) + 1;
			// int max_mc = counters.Max(x => x.Info.CollectedMemory.ToString("n0").Length) + 1;

			string f = "{0,-" + maxNameWidth + "}: " + string.Join(" ", columns.Select((s, i) => "{" + (i + 1) + "," + maxColWidth + ":n0}"));
			// if (ShowMemory) f += " Mem: {2," + max_mu + ":n0}B b/c, {3," + max_mc + ":n0}B a/c.";
			Console.WriteLine(f, (new[] { "#" }).Union(columns).ToArray());
			foreach (var k in counters) {
				Console.WriteLine(f, (new object[] { k.Line }).AsEnumerable().Union(k.Cells.Select(c => (object) c.Info.EllapsedMilliseconds)).ToArray());
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
