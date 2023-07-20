namespace Reactor.Transport.Sockets.Middleware
{
	internal class PipelineTerminationMiddleware : IMiddleware
    {
        public Task Invoke(ISocketContext context)
        {
            return Task.CompletedTask;
        }

        void IMiddleware.SetNext(MiddlewareDelegate next)
        {
        }
    }
}