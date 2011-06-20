using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;

namespace Main_4
{
	public class NinjectRunner : IDependencyInjectorRunner
	{
		IKernel k;
		public string Name {
			get { return "Ninject"; }
		}

		public void WarmUp() {
			k = new StandardKernel();
			k.Bind<IDummy>().To<SimpleDummy>().InSingletonScope();
		}

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
