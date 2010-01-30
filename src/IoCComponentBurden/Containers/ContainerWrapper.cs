namespace IoCComponentBurden.Containers
{
	using System;

	public abstract class ContainerWrapper:IDisposable
	{
		public abstract TService Resolve<TService>();

		public abstract void RegisterTransient<TService, TImpl>() where TImpl : class, TService;

		public abstract void RegisterSingleton<TService, TImpl>() where TImpl : class, TService;

		public abstract void Dispose();
	}

	public abstract class ContainerWrapper<TContainer> : ContainerWrapper where TContainer : IDisposable
	{
		protected TContainer container;

		public override void Dispose()
		{
			container.Dispose();
		}
	}
}