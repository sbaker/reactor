namespace Reactor.Transport.Sockets
{
	public interface ISocketRequest
    {
        ISocketContext Context { get; }

        int Length { get; }

        T? ReadAs<T>();

        string ReadAsString();

        Stream ReadAsStream();
    }
}