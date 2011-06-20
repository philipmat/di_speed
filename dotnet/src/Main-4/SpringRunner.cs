using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory.Xml;
using Spring.Core.IO;
using System.IO;
using Spring.Objects.Factory;

namespace Main_4
{
	public class SpringRunner : IDependencyInjectorRunner
	{
		IObjectFactory k;

		const string CONFIG = @"
<objects xmlns=""http://www.springframework.net"">
  <object name=""IDummy""
	type=""Main_4.SimpleDummy""
	singleton=""true""
	lazy-init=""true""
          />
</objects>";
		public string Name {
			get { return "Spring"; }
		}

		public void WarmUp() {

			// k = new XmlObjectFactory(new InputStreamResource(new MemoryStream(Encoding.UTF8.GetBytes(CONFIG)), "config"));
			k = new XmlApplicationContext("file://SpringConfig.xml");
			// var ctx = new GenericApplicationContext();
			// ctx.RegisterObjectDefinition
		}

		public void Run() {
			var t = typeof(IDummy).Name;
			if (k.ContainsObject(t))
				((IDummy) k.GetObject(t)).Do();
			else
				throw new InvalidOperationException(string.Format("{0} couldn't find a dummy to practice on.", this.Name));
		}
	}
}
