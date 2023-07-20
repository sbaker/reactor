using Reactor.Transport.Sockets.Middleware;

namespace Reactor.Transport.Sockets
{
	public interface ISocketConnection : IDisposable
    {
        void ConfigurePipeline(Action<IMiddlewarePipelineBuilder> builder);

        void UsePipeline(IMiddlewarePipeline pipeline);

        Task ConnectAsync(string address, int port);

        Task<ISocketConnection> AcceptAsync();

        Task<int> SendAsync(byte[] buffer);

        Task<int> ReceiveAsync(byte[] buffer);

        void Listen(int port);
    }
}
