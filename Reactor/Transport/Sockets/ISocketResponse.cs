namespace Reactor.Transport.Sockets
{
	public interface ISocketResponse
    {
        ISocketContext Context { get; }

        Task WriteAsync(string value);

        Task WriteAsync<T>(T value);
    }
}