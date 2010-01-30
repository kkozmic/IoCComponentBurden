namespace IoCComponentBurden.Model
{
	public class NonDisposableRepository : IRepository
	{
		private readonly ISession session;

		public NonDisposableRepository(ISession session)
		{
			this.session = session;
		}

		public ISession Session
		{
			get { return session;}
		}
	}
}