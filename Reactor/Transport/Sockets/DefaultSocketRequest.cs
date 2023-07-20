using Newtonsoft.Json;
using System.Text;

namespace Reactor.Transport.Sockets
{
	public class DefaultSocketRequest : ISocketRequest
    {
        public DefaultSocketRequest(byte[] buffer, ISocketContext context)
        {
            Buffer = buffer ?? throw new ArgumentNullException(nameof(buffer));
            Context = context;
        }

        public ISocketContext Context { get; }

        public int Length
        {
            get
            {
                return Buffer.Length;
            }
        }

        protected byte[] Buffer { get; }

        public T? ReadAs<T>()
        {
            return JsonConvert.DeserializeObject<T>(ReadAsString());
        }

        public Stream ReadAsStream()
        {
            return new MemoryStream(Buffer);
        }

        public string ReadAsString()
        {
            return Encoding.UTF8.GetString(Buffer);
        }
    }
}