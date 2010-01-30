namespace IoCComponentBurden.Containers
{
	using Funq;

	public class FunqContainerWrapper:ContainerWrapper<Container>
	{
		public FunqContainerWrapper()
		{
			container = new Container();
		}

		public override TService Resolve<TService>()
		{
			return container.Resolve<TService>();
		}

		public override void RegisterTransient<TService, TImpl>()
		{
			container.Register<TService, TImpl>((c, i) => /*what is this for?*/ i).ReusedWithin(ReuseScope.None);
		}

		public override void RegisterSingleton<TService, TImpl>()
		{
			container.Register<TService, TImpl>((c, i) => /*what is this for?*/ i).ReusedWithin(ReuseScope.Hierarchy);
		}
	}
}