
namespace Reactor.Actors
{
	public abstract class ReceivingActor : IActor
	{
		protected ReceivingActor(string fqn)
		{
			Fqn = fqn;
		}

		public string Fqn { get; internal set; }

		public abstract void OnInboxMessage(object message);
	}

	public abstract class ReceivingActor<T> : ReceivingActor, IActor<T>
	{
		protected ReceivingActor(string fqn) : base(fqn)
		{
		}

		public sealed override void OnInboxMessage(object message)
		{
			OnInboxMessage((T)message);
		}

		public abstract void OnInboxMessage(T message);
	}
}
