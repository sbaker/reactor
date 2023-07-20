using Reactor.Transport.Sockets.Middleware;

namespace Reactor.Transport.Sockets.Extensions
{
	public static class MiddlewareExtensions
    {
        public static IMiddlewarePipelineBuilder Use(this IMiddlewarePipelineBuilder builder, Func<ISocketContext, MiddlewareDelegate, Task> middleware)
        {
            builder.Use<DelegatingMiddleware>(() => new DelegatingMiddleware(middleware));
            return builder;
        }
    }
}