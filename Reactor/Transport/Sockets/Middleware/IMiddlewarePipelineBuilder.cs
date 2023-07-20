namespace Reactor.Transport.Sockets.Middleware
{
	public interface IMiddlewarePipelineBuilder
    {
        IMiddlewarePipeline Build();

        IMiddlewarePipelineBuilder Use<TMiddleware>(Func<TMiddleware> activator) where TMiddleware : class, IMiddleware;
    }
}