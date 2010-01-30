namespace IoCComponentBurden.Containers
{
	using Castle.Core;
	using Castle.Windsor;

	public class CastleWindsorContainerWrapper:ContainerWrapper<WindsorContainer>
	{
		public CastleWindsorContainerWrapper()
		{
			container = new WindsorContainer();
		}

		public override TService Resolve<TService>()
		{
			return container.Resolve<TService>();
		}

		public override void RegisterTransient<TService, TImpl>()
		{
			container.AddComponentLifeStyle<TService, TImpl>(LifestyleType.Transient);
		}

		public override void RegisterSingleton<TService, TImpl>() 
		{
			container.AddComponentLifeStyle<TService, TImpl>(LifestyleType.Singleton);
		}
	}
}