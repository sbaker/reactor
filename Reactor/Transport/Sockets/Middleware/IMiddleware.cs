namespace Reactor.Transport.Sockets.Middleware
{
	public interface IMiddleware
    {
        void SetNext(MiddlewareDelegate next);

        Task Invoke(ISocketContext context);
    }
}