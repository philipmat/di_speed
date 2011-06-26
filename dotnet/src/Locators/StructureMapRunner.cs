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

		public void WarmUp() {
			ObjectFactory.Initialize(x => x.For<IDummy>().Singleton().Use<SimpleDummy>());
		}

		public void Run() {
			IDummy d;
			if ((d = ObjectFactory.TryGetInstance<IDummy>()) != null)
				d.Do();
			else
				throw new InvalidOperationException(string.Format("{0} couldn't find a dummy to practice on.", this.Name));
		}
	}
}
