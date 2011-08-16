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

	public interface ILocatorMultiVar : IDisposable
	{
		string Name { get; }
		void WarmUp_Singleton(int howManyObjects);
		void WarmUp_NewEveryTime(int howManyObjects);
		void WarmUp_PerThread(int howManyObjects);
		void Run(Type t, string name);
	}
}
