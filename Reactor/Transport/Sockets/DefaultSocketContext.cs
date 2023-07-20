using System.Dynamic;

namespace Reactor.Transport.Sockets
{
    internal class DefaultSocketContext : ISocketContext
    {
        public DefaultSocketContext(byte[] buffer, ISocketConnection connection)
        {
            Connection = connection;
            Response = new DefaultSocketResponse(this);
            Request = new DefaultSocketRequest(buffer, this);
            Properties = new ExpandoObject();
        }

        public ISocketConnection Connection { get; }

        public ISocketRequest Request { get; }

        public ISocketResponse Response { get; }

        public dynamic Properties { get; }
    }
}