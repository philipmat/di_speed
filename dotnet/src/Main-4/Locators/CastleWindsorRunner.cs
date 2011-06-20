using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace Main_4.Locators
{
	public class CastleWindsorRunner : ILocator
	{
		IWindsorContainer k;
		public string Name {
			get { return "Castle Windsor"; }
		}

		public void WarmUp() {
			k = new WindsorContainer();
			k.Register(
				Component.For<IDummy>().ImplementedBy<SimpleDummy>().LifeStyle.Singleton
				);
		}

		public void Run() {
			if (k.Kernel.HasComponent(typeof(IDummy)))
				k.Resolve<IDummy>().Do();
			else
				throw new InvalidOperationException(string.Format("{0} couldn't find a dummy to practice on.", this.Name));
		}
	}
}
