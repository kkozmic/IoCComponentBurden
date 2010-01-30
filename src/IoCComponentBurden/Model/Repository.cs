namespace IoCComponentBurden.Model
{
	using System;

	public class Repository : IRepository,IDisposable
	{
		private readonly ISession session;
		public static bool Disposed;

		public Repository(ISession session)
		{
			this.session = session;
		}

		public ISession Session
		{
			get
			{
				return session;
			}
		}

		public void Dispose()
		{
			Disposed = true;
		}
	}
}