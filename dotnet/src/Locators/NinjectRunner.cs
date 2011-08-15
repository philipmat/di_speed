using System;
using Dummies;
using Ninject;

namespace Locators
{
	public class NinjectRunner : ILocator
	{
		IKernel k;
		public string Name {
			get { return "Ninject"; }
		}

		public void WarmUp_Singleton() {
			k = new StandardKernel();
			k.Bind<IDummy>().To<SimpleDummy>().InSingletonScope();
		}
		public void WarmUp_NewEveryTime() {
			k = new StandardKernel();
			k.Bind<IDummy>().To<SimpleDummy>().InTransientScope();
		}
		public void WarmUp_PerThread() { }

		public void Run() {
			k.Get<IDummy>().Do();
		}
	}
}
