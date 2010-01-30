namespace IoCComponentBurden.Containers
{
	using StructureMap;

	public class StructureMapContainerWrapper:ContainerWrapper<Container>
	{
		public StructureMapContainerWrapper()
		{
			container = new Container();
		}

		public override TService Resolve<TService>()
		{
			return container.GetInstance<TService>();
		}

		public override void RegisterTransient<TService, TImpl>()
		{
			container.Configure(c => c.For<TService>().AlwaysUnique().Use<TImpl>());
		}

		public override void RegisterSingleton<TService, TImpl>()
		{
			container.Configure(c => c.For<TService>().Singleton().Use<TImpl>());
		}
	}
}