namespace IoCComponentBurden.Model
{
	public interface IRepository
	{
		ISession Session { get; }
	}
}