using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace Main_4
{
	public class AutofacRunner : IDependencyInjectorRunner
	{
		IContainer k;
		public string Name { get { return "Autofac"; } }

		public void WarmUp() {
			var builder = new ContainerBuilder();
			builder.RegisterType<SimpleDummy>().As<IDummy>().SingleInstance();
			k = builder.Build();
		}

		public void Run() {
			if (k.IsRegistered<IDummy>())
				k.Resolve<IDummy>().Do();
			else
				throw new InvalidOperationException(string.Format("{0} couldn't find a dummy to practice on.", this.Name));
		}
	}
}
