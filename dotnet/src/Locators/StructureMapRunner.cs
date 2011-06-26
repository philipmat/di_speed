using System;
using Dummies;
using StructureMap;

namespace Locators
{
	public class StructureMapRunner : ILocator
	{
		public string Name {
			get { return "StructureMap"; }
		}

		public void WarmUp_Singleton() {
			ObjectFactory.Initialize(x => x.For<IDummy>().Singleton().Use<SimpleDummy>());
		}
		public void WarmUp_NewEveryTime() {
			ObjectFactory.Initialize(x => x.For<IDummy>().LifecycleIs(new StructureMap.Pipeline.UniquePerRequestLifecycle())
				.Use<SimpleDummy>());
		}
		public void WarmUp_PerThread() { }
		public void WarmUp_Loaded_Singleton() { }
		public void WarmUp_Loaded_NewEveryTime() { }
		public void WarmUp_Loaded_PerThread() { }

		public void Run() {
			IDummy d;
			if ((d = ObjectFactory.TryGetInstance<IDummy>()) != null)
				d.Do();
			else
				throw new InvalidOperationException(string.Format("{0} couldn't find a dummy to practice on.", this.Name));
		}
	}
}
