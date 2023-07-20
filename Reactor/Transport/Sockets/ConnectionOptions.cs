using System.Net.Sockets;

namespace Reactor.Transport.Sockets
{
	public class ConnectionOptions
    {
        public SocketType SocketType { get; set; } = SocketType.Stream;

        public ProtocolType ProtocolType { get; set; } = ProtocolType.IP;
    }
}