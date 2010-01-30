namespace IoCComponentBurden.Containers
{
	using Microsoft.Practices.Unity;

	public class UnityContainerWrapper:ContainerWrapper<UnityContainer>
	{
		public UnityContainerWrapper()
		{
			container = new UnityContainer();
		}

		public override TService Resolve<TService>()
		{
			return container.Resolve<TService>();
		}


		public override void RegisterTransient<TService, TImpl>()
		{
			container.RegisterType<TService, TImpl>(new TransientLifetimeManager());
		}

		public override void RegisterSingleton<TService, TImpl>()
		{
			container.RegisterType<TService, TImpl>(new ContainerControlledLifetimeManager());
		}
	}
}