using System;
using Dummies;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory.Xml;
using Spring.Core.IO;
using System.IO;
using Spring.Objects.Factory;
using System.Text;

namespace Locators
{
	public class SpringRunner : ILocator
	{
		IObjectFactory k;

		const string CONFIG_SINGLETON = @"
<objects xmlns=""http://www.springframework.net"">
  <object name=""IDummy"" type=""Dummies.SimpleDummy"" singleton=""true"" lazy-init=""true"" />
</objects>";


		const string CONFIG_TRANSIENT = @"
<objects xmlns=""http://www.springframework.net"">
  <object name=""IDummy"" type=""Dummies.SimpleDummy"" singleton=""false"" />
</objects>";

		public string Name {
			get { return "Spring"; }
		}

		public void WarmUp_Singleton() {

			k = new XmlObjectFactory(new InputStreamResource(new MemoryStream(Encoding.UTF8.GetBytes(CONFIG_SINGLETON)), "config"));
			// k = new XmlApplicationContext("file://SpringConfig.xml");
			// var ctx = new GenericApplicationContext();
			// ctx.RegisterObjectDefinition
		}
		public void WarmUp_NewEveryTime() {
			k = new XmlObjectFactory(new InputStreamResource(new MemoryStream(Encoding.UTF8.GetBytes(CONFIG_TRANSIENT)), "config"));
		}
		public void WarmUp_PerThread() { }
		public void WarmUp_Loaded_Singleton() { }
		public void WarmUp_Loaded_NewEveryTime() { }
		public void WarmUp_Loaded_PerThread() { }

		public void Run() {
			var t = typeof(IDummy).Name;
			((IDummy) k.GetObject(t)).Do();
		}
	}
}
