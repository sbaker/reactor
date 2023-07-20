using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reactor.Actors
{
	public abstract class SimpleActor : IActor
	{
		protected SimpleActor()
		{
		}

		public string Fqn { get; internal set; }

		public abstract void OnInboxMessage(object message);
	}
}
