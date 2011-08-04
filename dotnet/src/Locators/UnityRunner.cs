using System;
using Dummies;
using Microsoft.Practices.Unity;

namespace Locators
{
	public class UnityRunner : ILocator
	{
		IUnityContainer k;

		public string Name { get { return "Unity"; } }
		private void Register(Func<LifetimeManager> manager) {
			k = new UnityContainer();
			k.RegisterType<IDummy, SimpleDummy>(manager());
		}
		public void WarmUp_Singleton() {
			Register(() => new ContainerControlledLifetimeManager());
		}
		public void WarmUp_NewEveryTime() {
			Register(() => new TransientLifetimeManager()); // wonder if I should be using the PerResolve
		}
		public void WarmUp_PerThread() {
			Register(() => new PerThreadLifetimeManager());
		}
		public void WarmUp_Loaded_Singleton() { }
		public void WarmUp_Loaded_NewEveryTime() { }
		public void WarmUp_Loaded_PerThread() { }

		public void Run() {
			if (k.IsRegistered<IDummy>())
				k.Resolve<IDummy>().Do();
			else
				throw new InvalidOperationException(string.Format("{0} couldn't find a dummy to practice on.", this.Name));
		}
	}
}
