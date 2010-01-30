namespace IoCComponentBurden.Model
{
	public class Session : ISession
	{
		public static bool Disposed;
		private readonly IDataStore store;

		public Session(IDataStore store)
		{
			this.store = store;
		}

		public void Dispose()
		{
			Disposed = true;
		}

		public IDataStore Store
		{
			get { return store; }
		}
	}
}