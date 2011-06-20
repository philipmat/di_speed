using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Main_4
{
	public interface IDummy
	{
		void Do();
	}
	public class SimpleDummy : IDummy
	{
		public static bool BLOW_UP_IF_IN_CONSTRUCTOR = true;
		public SimpleDummy() {
			// System.Threading.Thread.Sleep(1000);
			if (BLOW_UP_IF_IN_CONSTRUCTOR)
				throw new InvalidOperationException("Somebody tried to cheat and not lazy initialize me.");
		}

		public void Do() {
		}
	}
}
