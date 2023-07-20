namespace Reactor
{
	public interface IReactorSystem
	{
		string Name { get; }

		ReactorSystem Start();
	}
}