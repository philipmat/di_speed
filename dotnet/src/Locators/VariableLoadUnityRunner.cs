
using System;
using Dummies;
using Microsoft.Practices.Unity;

namespace Locators
{	public class VariableLoadUnityRunner : ILocatorMultiVar
	{
		IUnityContainer k;
		Func<Type, string, IDummy> dummyResolver;
		const string I_NAME = "Dummies.IDummy{0}";
		const string C_NAME = "Dummies.SimpleDummy{0}";

		public VariableLoadUnityRunner(bool useIsRegistered = true) {
			if (useIsRegistered)
				this.dummyResolver = Run_IR;
			else
				this.dummyResolver = Run_Ex;
		}

		public string Name { get { return "Unity"; } }
		private void Register(int howManyInterfaces, Func<LifetimeManager> manager) {
			k = new UnityContainer();
			string @in, cn1, cn2, cn3;
			for (int i = 0; i < howManyInterfaces; i++)
			{
				@in = string.Format(I_NAME, i);
 				cn1 = string.Format(C_NAME, i*3);
				cn2 = string.Format(C_NAME, i*3 + 1);
				cn3 = string.Format(C_NAME, i*3 + 2);
				k.RegisterType(Type.GetType(@in), Type.GetType(cn1), "0", manager());
				k.RegisterType(Type.GetType(@in), Type.GetType(cn2), "1", manager());
				k.RegisterType(Type.GetType(@in), Type.GetType(cn3), "2", manager());
			}
		}
		public void WarmUp_Singleton(int howManyInterfaces) {
			Register(howManyInterfaces, () => new ContainerControlledLifetimeManager());
		}
		public void WarmUp_NewEveryTime(int howManyInterfaces) {
			Register(howManyInterfaces, () => new TransientLifetimeManager()); // wonder if I should be using the PerResolve
		}
		public void WarmUp_PerThread(int howManyInterfaces) {
			Register(howManyInterfaces, () => new PerThreadLifetimeManager());
		}

		public void Run() { throw new NotImplementedException(); }

		public void Run(Type t, string name) {
			IDummy d = dummyResolver(t, name);
			if (d != null) d.Do();
		}

		public IDummy Run_IR(Type t, string name) {
			if (k.IsRegistered(t, name))
				return ((IDummy) k.Resolve(t, name));
			return null;
		}

		public IDummy Run_Ex(Type t, string name) {
			try {
				return (IDummy) k.Resolve(t, name);
			}  catch (ResolutionFailedException) {
				return null;
			}
		}
	}
}
