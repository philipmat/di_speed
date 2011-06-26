namespace Locators
{
	public interface ILocator
	{
		string Name { get; }
		void WarmUp();
		void Run();
	}
}
