namespace Reactor.Transport.Sockets.Middleware
{
	public class MiddlewarePipeline : IMiddlewarePipeline
    {
        private readonly IMiddleware _start;

        public MiddlewarePipeline(IMiddleware startingMiddleware)
        {
            _start = startingMiddleware;
        }

        public async Task ExecuteAsync(ISocketContext context)
        {
            await _start.Invoke(context);
        }
    }
}