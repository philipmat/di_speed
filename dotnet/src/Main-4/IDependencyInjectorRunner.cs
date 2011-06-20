using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Main_4
{
	public interface IDependencyInjectorRunner
	{
		string Name { get; }
		void WarmUp();
		void Run();
	}
}
