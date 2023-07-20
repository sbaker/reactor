using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reactor.Actors
{
    public interface IActor
	{
		string Fqn { get; }

		void OnInboxMessage(object message);
	}

	public interface IActor<T> : IActor
	{
		void OnInboxMessage(T message);
	}
}
