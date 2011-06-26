using System;

namespace Dummies
{
	public interface IDummy
	{
		void Do();
	}
	public class SimpleDummy : IDummy
	{
		public static long BLOW_UP_IF_COUNTER_LARGER_THAN = 0;
		public static long COUNTER = 0;
		public SimpleDummy() {
			// System.Threading.Thread.Sleep(1000);
			COUNTER++;
			if (COUNTER > BLOW_UP_IF_COUNTER_LARGER_THAN)
				throw new InvalidOperationException("Somebody tried to cheat and not lazy initialize me.");
		}

		public void Do() {
		}
	}
}
