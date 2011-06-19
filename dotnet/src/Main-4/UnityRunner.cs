using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

namespace Main_4
{
	public class UnityRunner : IDependencyInjectorRunner
	{
		IUnityContainer k;

		public string Name { get { return "Unity"; } }
		public void WarmUp() {
			k = new UnityContainer();
			k.RegisterType<IDummy, SimpleDummy>();
		}

		public void Run(int numberOfTimes) {
			for (var i=0; i < numberOfTimes; i++) {
				if (k.IsRegistered<IDummy>())
					k.Resolve<IDummy>().Do();
			}
		}
	}
}
