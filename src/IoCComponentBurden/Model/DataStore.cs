namespace IoCComponentBurden.Model
{
	using System;

	public class DataStore : IDataStore, IDisposable
	{
		public static bool Disposed;

		public void Dispose()
		{
			Disposed = true;
		}
	}
}