using System;
namespace Locators
{
	public interface ILocator
	{
		string Name { get; }
		void WarmUp_Singleton();
		void WarmUp_NewEveryTime();
		void WarmUp_PerThread();
		void Run();
	}

	public interface ILocatorMulti : ILocator
	{
		void Run(Type t, string name);
	}
}
