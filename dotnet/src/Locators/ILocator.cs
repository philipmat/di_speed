namespace Locators
{
	public interface ILocator
	{
		string Name { get; }
		void WarmUp_Singleton();
		void WarmUp_NewEveryTime();
		void WarmUp_PerThread();
		void WarmUp_Loaded_Singleton();
		void WarmUp_Loaded_NewEveryTime();
		void WarmUp_Loaded_PerThread();
		void Run();
	}
}
