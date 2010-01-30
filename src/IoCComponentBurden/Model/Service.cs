namespace IoCComponentBurden.Model
{
	public class Service : IService
	{
		private readonly IRepository repository;

		public Service(IRepository repository)
		{
			this.repository = repository;
		}

		public IRepository Repository
		{
			get { return repository; }
		}
	}
}