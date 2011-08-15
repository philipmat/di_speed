using System;
using Dummies;
using Autofac;

namespace Locators
{
	public class AutofacRunner : ILocator
	{
		IContainer k;
		public string Name { get { return "Autofac"; } }

		public void WarmUp_Singleton() {
			var builder = new ContainerBuilder();
			builder.RegisterType<SimpleDummy>().As<IDummy>().SingleInstance();
			k = builder.Build();
		}
		public void WarmUp_NewEveryTime() {
			var builder = new ContainerBuilder();
			builder.RegisterType<SimpleDummy>().As<IDummy>();
			k = builder.Build();
		}

		public void WarmUp_PerThread() { }


		public void Run() {
			k.Resolve<IDummy>().Do();
		}



	}
}
