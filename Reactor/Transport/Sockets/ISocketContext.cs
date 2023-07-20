namespace Reactor.Transport.Sockets
{
    public interface ISocketContext
    {
        dynamic Properties { get; }

        ISocketConnection Connection { get; }

        ISocketRequest Request { get; }

        ISocketResponse Response { get; }
    }
}