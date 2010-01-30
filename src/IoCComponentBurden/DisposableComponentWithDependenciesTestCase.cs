namespace IoCComponentBurden
{
	using System;

	using IoCComponentBurden.Containers;
	using IoCComponentBurden.Model;

	using NUnit.Framework;

	[TestFixture]
	public class DisposableComponentWithDependenciesTestCase
	{
		private void Execute<TScenatio>() where TScenatio : ContainerWrapper, new()
		{
			var scenario = new TScenatio();
			DataStore.Disposed = false;
			Session.Disposed = false;
			Repository.Disposed = false;

			scenario.RegisterSingleton<IDataStore, DataStore>();
			scenario.RegisterTransient<ISession, Session>();
			scenario.RegisterTransient<IRepository, NonDisposableRepository>();
			scenario.RegisterTransient<IDisposableService, DisposableService>();

			var service = scenario.Resolve<IDisposableService>();
			var serviceReference = new WeakReference(service);
			var repositoryReference = new WeakReference(service.Repository);
			var sessionReference = new WeakReference(service.Repository.Session);
			var dataStoreReference = new WeakReference(service.Repository.Session.Store);
			service.Dispose();
			service = null;
			GC.Collect();
			Console.WriteLine("serviceReference.IsAlive: {0}", serviceReference.IsAlive);
			Console.WriteLine("repositoryReference.IsAlive: {0}", repositoryReference.IsAlive);
			Console.WriteLine("sessionReference.IsAlive: {0}", sessionReference.IsAlive);
			Console.WriteLine("dataStoreReference.IsAlive: {0}", dataStoreReference.IsAlive);

			Console.WriteLine("-----Disposing the container");
			scenario.Dispose();

			GC.Collect();
			Console.WriteLine("serviceReference.IsAlive: {0}", serviceReference.IsAlive);
			Console.WriteLine("repositoryReference.IsAlive: {0}", repositoryReference.IsAlive);
			Console.WriteLine("sessionReference.IsAlive: {0}", sessionReference.IsAlive);
			Console.WriteLine("dataStoreReference.IsAlive: {0}", dataStoreReference.IsAlive);

			Console.WriteLine("DataStore.Disposed: {0}", DataStore.Disposed);
			Console.WriteLine("Session.Disposed: {0}", Session.Disposed);
			Console.WriteLine("DisposableService.Disposed: {0}", DisposableService.Disposed);
		}

		[Test]
		public void AutofacScenario()
		{
			Execute<AutoFacContainerWrapper>();
		}

		[Test]
		[Ignore("Funq is unable to construct dependency tree?")]
		public void FunqScenario()
		{
			Execute<FunqContainerWrapper>();
		}

		[Test]
		[Ignore("Not implemented yet. LinFu container does not implement IDisposable?")]
		public void LinFuScenario()
		{
			Execute<LinFuContainerWrapper>();
		}

		[Test]
		public void NInjectScenario()
		{
			Execute<NInjectContainerWrapper>();
		}

		[Test]
		public void StuctureMapScenario()
		{
			Execute<StructureMapContainerWrapper>();
		}

		[Test]
		public void UnityScenario()
		{
			Execute<UnityContainerWrapper>();
		}

		[Test]
		public void WindsorScenario()
		{
			Execute<CastleWindsorContainerWrapper>();
		}
	}
}