using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Generators
{
	class Program
	{
		const int NUM_I = 222;
		const int K_TO_I = 3;
		static void Main(string[] args) {
			string dummies, runners;
			var cwd = System.IO.Directory.GetCurrentDirectory();
			if (cwd.Contains(string.Format("{0}Generators{0}bin{0}", Path.DirectorySeparatorChar))) {
				dummies = string.Format("..{0}..{0}..{0}Dummies{0}{{0}}", Path.DirectorySeparatorChar);
				runners = string.Format("..{0}..{0}..{0}Locators{0}{{0}}", Path.DirectorySeparatorChar);
			} else {
				dummies = runners = "{0}";
			}
			using (var f = new StreamWriter(string.Format(dummies, "MultiDummy.cs"))) { GenerateDummies(f); }
			using (var f = new StreamWriter(string.Format(runners, "LoadedAutofacRunner.cs"))) { Generate_Autofac(f); }
			using (var f = new StreamWriter(string.Format(runners, "LoadedCastleWindsorRunner.cs"))) { Generate_CastleWindsor(f); }
			using (var f = new StreamWriter(string.Format(runners, "LoadedNinjectRunner.cs"))) { Generate_Ninject(f); }
			using (var f = new StreamWriter(string.Format(runners, "LoadedSpringRunner.cs"))) { Generate_Spring(f); }
			using (var f = new StreamWriter(string.Format(runners, "LoadedStructureMapRunner.cs"))) { Generate_StructureMap(f); }
			using (var f = new StreamWriter(string.Format(runners, "LoadedUnityRunner.cs"))) { Generate_Unity(f); }
			
		}

		static void GenerateDummies(TextWriter @out) {
			@out.Write(@"
namespace Dummies {

#region Interfaces 

");
			string dummyFace = " interface IDummy{0} : IDummy {{ void DoMore(); }}\r\n";
			string dummyBody = @"
	public class SimpleDummy{0} : IDummy{1} {{
		public SimpleDummy{0}() {{}}
		public void Do() {{}}
		public void DoMore() {{}}
	}}
";
			for (var i = 0; i < NUM_I; i++) {
				@out.Write(dummyFace, i);
			}

			@out.Write(@"
#endregion
#region Implementation\r\n");
			int K = NUM_I * K_TO_I;
			for (var k = 0; k < K ; k++) {
				int i = k / K_TO_I;
				@out.Write(dummyBody, k, i);
			}

			@out.Write(@"
#endregion
}");
		}

		static void Generate_Autofac(TextWriter @out) {
			var sb_s = new StringBuilder();
			var sb_n = new StringBuilder();
			var K = NUM_I * K_TO_I;
			for (var k = 0; k < K; k++) {
				int i = k / K_TO_I;
				sb_s.AppendFormat("builder.RegisterType<SimpleDummy{0}>().Named<IDummy{1}>(\"{2}\").SingleInstance();\r\n", k, i, k % K_TO_I);
				sb_n.AppendFormat("builder.RegisterType<SimpleDummy{0}>().Named<IDummy{1}>(\"{2}\");\r\n", k, i, k % K_TO_I);
			}
			@out.Write(
@"
using System;
using Dummies;
using Autofac;

namespace Locators
{
	public class LoadedAutofacRunner : ILocatorMulti
	{
		IContainer k;
		public string Name { get { return ""Autofac""; } }

		public void WarmUp_Singleton() {
			var builder = new ContainerBuilder();
" + sb_s.ToString() + @"
			k = builder.Build();
		}
		public void WarmUp_NewEveryTime() {
			var builder = new ContainerBuilder();
"  + sb_n.ToString() + @"
			k = builder.Build();
		}

		public void WarmUp_PerThread() { }

		public void Run() { throw new NotImplementedException(); }

		public void Run(Type t, string name) {
			if (k.IsRegisteredWithName(name, t))
				((IDummy) k.ResolveNamed(name, t)).Do();
			else
				throw new InvalidOperationException(string.Format(""{0} couldn't find a dummy to practice on."", this.Name));
		}
	}
}
");
		}

		static void Generate_CastleWindsor(TextWriter @out){
			var sb_s = new StringBuilder();
			var sb_n = new StringBuilder();
			var K = NUM_I * K_TO_I;
			for (var k = 0; k < K; k++) {
				int i = k / K_TO_I;
				sb_s.AppendFormat("k.Register(Component.For<IDummy{1}>().ImplementedBy<SimpleDummy{0}>().Named(\"IDummy{1}_{2}\").LifeStyle.Singleton);\r\n", k, i, k % K_TO_I);
				sb_n.AppendFormat("k.Register(Component.For<IDummy{1}>().ImplementedBy<SimpleDummy{0}>().Named(\"IDummy{1}_{2}\").LifeStyle.Transient);\r\n", k, i, k % K_TO_I);
			}
			@out.Write(
@"
using System;
using Dummies;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace Locators
{
	public class LoadedCastleWindsorRunner : ILocatorMulti
	{
		IWindsorContainer k;
		public string Name {
			get { return ""Castle Windsor""; }
		}

		public void WarmUp_Singleton() {
			k = new WindsorContainer();
" + sb_s.ToString() + @"
		}
		public void WarmUp_NewEveryTime() {
			k = new WindsorContainer();
" + sb_n.ToString() + @"
		}
		public void WarmUp_PerThread() { }

		public void Run() { throw new NotImplementedException(); }

		public void Run(Type t, string name) {
			var componentName = string.Format(""{1}_{0}"", name, t.Name);
			if (k.Kernel.HasComponent(componentName))
				((IDummy) k.Resolve(componentName, t)).Do();
			else
				throw new InvalidOperationException(string.Format(""{0} couldn't find a dummy to practice on."", this.Name));
		}
	}
}
");
		}


		static void Generate_Ninject(TextWriter @out) {
			var sb_s = new StringBuilder();
			var sb_n = new StringBuilder();
			var K = NUM_I * K_TO_I;
			for (var k = 0; k < K; k++) {
				int i = k / K_TO_I;
				sb_s.AppendFormat("k.Bind<IDummy{1}>().To<SimpleDummy{0}>().InSingletonScope().Named(\"{2}\");\r\n", k, i, k % K_TO_I);
				sb_n.AppendFormat("k.Bind<IDummy{1}>().To<SimpleDummy{0}>().InTransientScope().Named(\"{2}\");\r\n", k, i, k % K_TO_I);
			}
			@out.Write(
@"
using System;
using Dummies;
using Ninject;

namespace Locators
{
	public class LoadedNinjectRunner : ILocatorMulti
	{
		IKernel k;
		public string Name {
			get { return ""Ninject""; }
		}

		public void WarmUp_Singleton() {
			k = new StandardKernel();
" + sb_s.ToString() + @"
		}
		public void WarmUp_NewEveryTime() {
			k = new StandardKernel();
" + sb_n.ToString() + @"
		}
		public void WarmUp_PerThread() { }

		public void Run() { throw new NotImplementedException(); }

		public void Run(Type t, string name) {
			IDummy d;
			if ((d = (k.TryGet(t, name) as IDummy)) != null)
				d.Do();
			else
				throw new InvalidOperationException(string.Format(""{0} couldn't find a dummy to practice on."", this.Name));
		}
	}
}");
		}

		static void Generate_Spring(TextWriter @out) {
			var sb_s = new StringBuilder();
			var sb_n = new StringBuilder();
			var K = NUM_I * K_TO_I;
			for (var k = 0; k < K; k++) {
				int i = k / K_TO_I;
				sb_s.AppendFormat("<object name=\"\"IDummy{1}_{2}\"\" type=\"\"Dummies.SimpleDummy{0}\"\" singleton=\"\"true\"\" lazy-init=\"\"true\"\" />\r\n", k, i, k % K_TO_I);
				sb_n.AppendFormat("<object name=\"\"IDummy{1}_{2}\"\" type=\"\"Dummies.SimpleDummy{0}\"\" singleton=\"\"false\"\" />\r\n", k, i, k % K_TO_I);
			}
			@out.Write(
@"
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
	public class LoadedSpringRunner : ILocatorMulti
	{
		IObjectFactory k;

		const string CONFIG_SINGLETON = @""
<objects xmlns=""""http://www.springframework.net"""">
" + sb_s.ToString() + @"
</objects>"";


		const string CONFIG_TRANSIENT = @""
<objects xmlns=""""http://www.springframework.net"""">
" + sb_n.ToString() + @"
</objects>"";

		public string Name {
			get { return ""Spring""; }
		}

		public void WarmUp_Singleton() {

			k = new XmlObjectFactory(new InputStreamResource(new MemoryStream(Encoding.UTF8.GetBytes(CONFIG_SINGLETON)), ""config""));
			// k = new XmlApplicationContext(""file://SpringConfig.xml"");
			// var ctx = new GenericApplicationContext();
			// ctx.RegisterObjectDefinition
		}
		public void WarmUp_NewEveryTime() {
			k = new XmlObjectFactory(new InputStreamResource(new MemoryStream(Encoding.UTF8.GetBytes(CONFIG_TRANSIENT)), ""config""));
		}
		public void WarmUp_PerThread() { }

		public void Run() { throw new NotImplementedException(); }

		public void Run(Type t, string name) {
			var typeKey = string.Format(""{0}_{1}"", t.Name, name);
			if (k.ContainsObject(typeKey))
				((IDummy) k.GetObject(typeKey)).Do();
			else
				throw new InvalidOperationException(string.Format(""{0} couldn't find a dummy to practice on."", this.Name));
		}
	}
}"
);
		}

		static void Generate_StructureMap(TextWriter @out) {
			var sb_s = new StringBuilder();
			var sb_n = new StringBuilder();
			var K = NUM_I * K_TO_I;
			for (var k = 0; k < K; k++) {
				int i = k / K_TO_I;
				sb_s.AppendFormat("x.For<IDummy{1}>().Singleton().Use<SimpleDummy{0}>().Named(\"{2}\");\r\n", k, i, k % K_TO_I);
				sb_n.AppendFormat("x.For<IDummy{1}>().LifecycleIs(new StructureMap.Pipeline.UniquePerRequestLifecycle()).Use<SimpleDummy{0}>().Named(\"{2}\");\r\n", k, i, k % K_TO_I);
			}
			@out.Write(
@"
using System;
using Dummies;
using StructureMap;

namespace Locators
{
	public class LoadedStructureMapRunner : ILocatorMulti
	{
		public string Name {
			get { return ""StructureMap""; }
		}

		public void WarmUp_Singleton() {
			ObjectFactory.Initialize(x => {
" + sb_s.ToString() + @"
			});
		}
		public void WarmUp_NewEveryTime() {
			ObjectFactory.Initialize(x => {
" + sb_n.ToString() + @"
			});
		}
		public void WarmUp_PerThread() { }

		public void Run() { throw new NotImplementedException(); }

		public void Run(Type t, string name) {
			IDummy d;
			if ((d = (ObjectFactory.TryGetInstance(t, name) as IDummy)) != null)
				d.Do();
			else
				throw new InvalidOperationException(string.Format(""{0} couldn't find a dummy to practice on."", this.Name));
		}
	}
}
");
		}

		static void Generate_Unity(TextWriter @out) {
			var sb_s = new StringBuilder();
			var K = NUM_I * K_TO_I;
			for (var k = 0; k < K; k++) {
				int i = k / K_TO_I;
				sb_s.AppendFormat("k.RegisterType<IDummy{1}, SimpleDummy{0}>(\"{2}\", manager());\r\n", k, i, k % K_TO_I);
			}
			@out.Write(
@"
using System;
using Dummies;
using Microsoft.Practices.Unity;

namespace Locators
{	public class LoadedUnityRunner : ILocatorMulti
	{
		IUnityContainer k;
		Func<Type, string, IDummy> dummyResolver;
		public LoadedUnityRunner(bool useIsRegistered = true) {
			if (useIsRegistered)
				this.dummyResolver = Run_IR;
			else
				this.dummyResolver = Run_Ex;
		}

		public string Name { get { return ""Unity""; } }
		private void Register(Func<LifetimeManager> manager) {
			k = new UnityContainer();
" + sb_s.ToString() + @"
		}
		public void WarmUp_Singleton() {
			Register(() => new ContainerControlledLifetimeManager());
		}
		public void WarmUp_NewEveryTime() {
			Register(() => new TransientLifetimeManager()); // wonder if I should be using the PerResolve
		}
		public void WarmUp_PerThread() {
			Register(() => new PerThreadLifetimeManager());
		}

		public void Run() { throw new NotImplementedException(); }

		public void Run(Type t, string name) {
			IDummy d = dummyResolver(t, name);
			if (d != null) d.Do();
		}

		public IDummy Run_IR(Type t, string name) {
			if (k.IsRegistered(t, name))
				return ((IDummy) k.Resolve(t, name));
			else
				throw new InvalidOperationException(string.Format(""{0} couldn't find a dummy to practice on."", this.Name));
		}

		public IDummy Run_Ex(Type t, string name) {
			try {
				return k.Resolve<IDummy>();
			}  catch (ResolutionFailedException) {
				return null;
			}
		}
	}
}
");
		}

		
	}
}
