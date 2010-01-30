namespace IoCComponentBurden.Containers
{
	using Autofac;

	public class AutoFacContainerWrapper:ContainerWrapper<IContainer>
	{
		private readonly ContainerBuilder builder;

		public AutoFacContainerWrapper()
		{
			builder = new ContainerBuilder();
		}

		public override TService Resolve<TService>()
		{
			if (container == null)
			{
				container = builder.Build();
			}

			return container.Resolve<TService>();
		}

		public override void RegisterTransient<TService, TImpl>()
		{
			builder.RegisterType<TImpl>().As<TService>().InstancePerDependency();
		}

		public override void RegisterSingleton<TService,TImpl>()
		{
			builder.RegisterType<TImpl>().As<TService>().SingleInstance();
		}
	}
}