
using System;
using Dummies;
using Autofac;

namespace Locators
{
	public class VariableLoadAutofacRunner : ILocatorMultiVar
	{
		IContainer k;
		Func<Type, string, IDummy> dummyResolver;
		const string I_NAME = "Dummies.IDummy{0}";
		const string C_NAME = "Dummies.SimpleDummy{0}";

		public VariableLoadAutofacRunner(bool useIsRegistered = true) {
			if (useIsRegistered)
				this.dummyResolver = Run_IR;
			else
				this.dummyResolver = Run_Ex;
		}
		public string Name { get { return "Autofac"; } }



		public void WarmUp_Singleton(int howManyInterfaces) {
			var builder = new ContainerBuilder();
			string @in, cn1, cn2, cn3;
			for (int i = 0; i < howManyInterfaces; i++) {
				@in = string.Format(I_NAME, i);
				cn1 = string.Format(C_NAME, i * 3);
				cn2 = string.Format(C_NAME, i * 3 + 1);
				cn3 = string.Format(C_NAME, i * 3 + 2);
				builder.RegisterType(Type.GetType(cn1)).Named("0", Type.GetType(@in)).SingleInstance();
				builder.RegisterType(Type.GetType(cn1)).Named("1", Type.GetType(@in)).SingleInstance();
				builder.RegisterType(Type.GetType(cn1)).Named("2", Type.GetType(@in)).SingleInstance();
			}
			k = builder.Build();
		}


		public void WarmUp_NewEveryTime(int howManyInterfaces) {
			var builder = new ContainerBuilder();
			string @in, cn1, cn2, cn3;
			for (int i = 0; i < howManyInterfaces; i++) {
				@in = string.Format(I_NAME, i);
				cn1 = string.Format(C_NAME, i * 3);
				cn2 = string.Format(C_NAME, i * 3 + 1);
				cn3 = string.Format(C_NAME, i * 3 + 2);
				builder.RegisterType(Type.GetType(cn1)).Named("0", Type.GetType(@in));
				builder.RegisterType(Type.GetType(cn1)).Named("1", Type.GetType(@in));
				builder.RegisterType(Type.GetType(cn1)).Named("2", Type.GetType(@in));
			}
			k = builder.Build();
		}

		public void WarmUp_PerThread(int howManyInterfaces) { }

		public void Run() { throw new NotImplementedException(); }

		public void Run(Type t, string name) {
			IDummy d = dummyResolver(t, name);
			if (d != null) d.Do();
		}
		
		public IDummy Run_IR(Type t, string name) {
			if (k.IsRegisteredWithName(name, t))
				return (IDummy) k.ResolveNamed(name, t);
			return null;
		}

		public IDummy Run_Ex(Type t, string name) {
			try {
				return (IDummy) k.ResolveNamed(name, t);
			} catch (Autofac.Core.Registration.ComponentNotRegisteredException) {
				return null;
			}

		}
	}
}
