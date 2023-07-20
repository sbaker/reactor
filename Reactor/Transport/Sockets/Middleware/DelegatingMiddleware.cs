namespace Reactor.Transport.Sockets.Middleware
{
	internal class DelegatingMiddleware : DefaultMiddleware
    {
        private readonly Func<ISocketContext, MiddlewareDelegate, Task> _middleware;

        public DelegatingMiddleware(Func<ISocketContext, MiddlewareDelegate, Task> middleware)
        {
            _middleware = middleware ?? throw new ArgumentNullException(nameof(middleware));
        }

        public override Task Invoke(ISocketContext context)
        {
            return _middleware(context, (c) => Next(c));
        }
    }
}