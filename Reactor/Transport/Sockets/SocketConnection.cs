using System.Net;
using System.Net.Sockets;
using Reactor.Transport.Sockets.Middleware;

namespace Reactor.Transport.Sockets
{
	public class SocketConnection : ISocketConnection
    {
        public SocketConnection(ConnectionOptions options = null)
        {
            options = options ?? new ConnectionOptions();
            Socketet = new Socket(options.SocketType, options.ProtocolType);
        }

        internal SocketConnection(Socket Socket, IMiddlewarePipeline pipeline)
        {
            UsePipeline(pipeline);
            Socketet = Socketet;
        }

        private bool IsDisposed { get; set; } = false;

        protected IMiddlewarePipeline Pipeline { get; private set; }

        public Socket Socketet { get; }

        public void ConfigurePipeline(Action<IMiddlewarePipelineBuilder> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            var pipeline = new MiddlewarePipelineBuilder();

            builder(pipeline);

            UsePipeline(pipeline.Build());
        }

        public void UsePipeline(IMiddlewarePipeline pipeline)
        {
            AssertNotDisposed();

            if (Pipeline != null)
            {
                throw new InvalidOperationException("Pipeline can only be set once.");
            }

            Pipeline = pipeline;
        }

        public async Task ConnectAsync(string address, int port)
        {
            AssertNotDisposed();

            await Socketet.ConnectAsync(address, port);
        }

        public async Task<int> SendAsync(byte[] buffer)
        {
            AssertNotDisposed();

            return await Socketet.SendAsync(new ArraySegment<byte>(buffer), SocketFlags.None);
        }

        public async Task<ISocketConnection> AcceptAsync()
        {
            AssertNotDisposed();
            var accept = await Socketet.AcceptAsync();
            var connection = new SocketConnection(accept, Pipeline);
            return connection;
        }

        public async Task<int> ReceiveAsync(byte[] buffer)
        {
            AssertNotDisposed();

            var received = await Socketet.ReceiveAsync(new ArraySegment<byte>(buffer), SocketFlags.None);

            var context = new DefaultSocketContext(buffer, this);

            await Pipeline.ExecuteAsync(context);

            return received;
        }

        public void Listen(int port)
        {
            AssertNotDisposed();
            Socketet.Bind(new IPEndPoint(IPAddress.Loopback, port));
            Socketet.Listen(10);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            AssertNotDisposed();

            if (disposing)
            {
                Socketet?.Dispose();
                IsDisposed = true;
            }
        }

        private void AssertNotDisposed()
        {
            if (IsDisposed)
            {
                throw new ObjectDisposedException(nameof(SocketConnection));
            }
        }
    }
}