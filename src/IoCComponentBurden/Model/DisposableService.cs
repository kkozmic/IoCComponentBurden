namespace IoCComponentBurden.Model
{
	public class DisposableService : Service, IDisposableService
	{
		public static bool Disposed;

		public DisposableService(IRepository repository)
			: base(repository)
		{
		}

		public void Dispose()
		{
			Disposed = true;
		}
	}
}