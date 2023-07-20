using Newtonsoft.Json;
using System.Text;

namespace Reactor.Transport.Sockets
{
	public class DefaultSocketResponse : ISocketResponse
    {
        public DefaultSocketResponse(ISocketContext context)
        {
            Context = context;
        }

        public ISocketContext Context { get; }

        public async Task WriteAsync(string value)
        {
            await Context.Connection.SendAsync(Encoding.UTF8.GetBytes(value));
        }

        public async Task WriteAsync<T>(T value)
        {
            await WriteAsync(JsonConvert.SerializeObject(value));
        }
    }
}