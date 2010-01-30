namespace IoCComponentBurden.Containers
{
	using System;
	using System.Threading;

	using LinFu.IoC;

	public class LinFuContainerWrapper : ContainerWrapper
	{
		private ServiceContainer container;

		public LinFuContainerWrapper()
		{
			container = new ServiceContainer();

		}

		public override TService Resolve<TService>()
		{
			throw new NotImplementedException();
		}

		public override void RegisterTransient<TService, TImpl>()
		{
			throw new NotImplementedException();
		}

		public override void RegisterSingleton<TService, TImpl>()
		{
			throw new NotImplementedException();
		}

		public override void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}