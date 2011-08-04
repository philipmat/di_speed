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
			// if (k.CanResolve(k.CreateRequest(typeof(IDummy), binding => true, new Ninject.Parameters.IParameter[0], false, false)))
			// 	k.Get<IDummy>().Do();
			IDummy d;
			if ((d = k.TryGet<IDummy>()) != null)
				d.Do();
			else
				throw new InvalidOperationException(string.Format("{0} couldn't find a dummy to practice on.", this.Name));

		}
	}
}
