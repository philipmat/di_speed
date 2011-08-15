using System;
using Dummies;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace Locators
{
	public class CastleWindsorRunner : ILocator
	{
		IWindsorContainer k;
		public string Name {
			get { return "Castle Windsor"; }
		}

		public void WarmUp_Singleton() {
			k = new WindsorContainer();
			k.Register(
				Component.For<IDummy>().ImplementedBy<SimpleDummy>().LifeStyle.Singleton
				);
		}
		public void WarmUp_NewEveryTime() {
			k = new WindsorContainer();
			k.Register(
				Component.For<IDummy>().ImplementedBy<SimpleDummy>().LifeStyle.Transient
				);
		}
		public void WarmUp_PerThread() { }
		public void WarmUp_Loaded_Singleton() { }
		public void WarmUp_Loaded_NewEveryTime() { }
		public void WarmUp_Loaded_PerThread() { }

		public void Run() {
			k.Resolve<IDummy>().Do();
		}



	}
}
