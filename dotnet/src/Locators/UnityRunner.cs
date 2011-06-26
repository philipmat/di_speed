using System;
using Dummies;
using Microsoft.Practices.Unity;

namespace Locators
{
	public class UnityRunner : ILocator
	{
		IUnityContainer k;

		public string Name { get { return "Unity"; } }
		public void WarmUp() {
			k = new UnityContainer();
			k.RegisterType<IDummy, SimpleDummy>(new ContainerControlledLifetimeManager());
		}

		public void Run() {
			if (k.IsRegistered<IDummy>())
				k.Resolve<IDummy>().Do();
			else
				throw new InvalidOperationException(string.Format("{0} couldn't find a dummy to practice on.", this.Name));
		}
	}
}
