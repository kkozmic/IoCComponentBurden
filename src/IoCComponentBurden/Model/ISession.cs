namespace IoCComponentBurden.Model
{
	using System;

	public interface ISession : IDisposable
	{
		IDataStore Store { get; }
	}
}