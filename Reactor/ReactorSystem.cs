using Reactor.Actor;

namespace Reactor
{
	public class ReactorSystem : IReactorSystem
	{
		private ReactorSystem(string name)
		{
			Name = name;
		}

		public string Name { get; }

		public static IReactorSystem Create(string name)
		{
			return new ReactorSystem(name);
		}

		public ReactorSystem Start()
		{
			return this;
		}

		public IActor
	}
}