namespace IoCComponentBurden.Containers
{
	using Ninject;

	public class NInjectContainerWrapper:ContainerWrapper<StandardKernel>
	{
		public NInjectContainerWrapper()
		{
			container = new StandardKernel();
		}

		public override TService Resolve<TService>()
		{
			return container.Get<TService>();
		}

		public override void RegisterTransient<TService, TImpl>()
		{
			container.Bind<TService>().To<TImpl>().InTransientScope();
		}

		public override void RegisterSingleton<TService, TImpl>()
		{
			container.Bind<TService>().To<TImpl>().InSingletonScope();
		}
	}
}