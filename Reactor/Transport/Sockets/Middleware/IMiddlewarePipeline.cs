namespace Reactor.Transport.Sockets.Middleware
{
	public interface IMiddlewarePipeline
    {
        Task ExecuteAsync(ISocketContext context);
    }
}