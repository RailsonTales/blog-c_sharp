using System.Net.WebSockets;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Http;
using Blog.Entities;

namespace Blog.Services
{
    public class EnviarMensagemWebSockets
    {
        public EnviarMensagemWebSockets()
        {
            
        }

        public static async Task Conectando(string mensagem)
        {
            using var ws = new ClientWebSocket();
            await ws.ConnectAsync(new Uri("ws://localhost:5179"), CancellationToken.None);

            var retornoWebSockets = EnviarMensagemWebSockets.SendString(ws, mensagem, CancellationToken.None);
        }

        public static Task SendString(ClientWebSocket ws, String data, CancellationToken cancellation)
        {
            var encoded = Encoding.UTF8.GetBytes(data);
            var buffer = new ArraySegment<Byte>(encoded, 0, encoded.Length);
            return ws.SendAsync(buffer, WebSocketMessageType.Text, true, cancellation);
        }

        public static async Task<String> ReadString(ClientWebSocket ws)
        {
            ArraySegment<Byte> buffer = new ArraySegment<byte>(new Byte[8192]);

            WebSocketReceiveResult result = null;

            using (var ms = new MemoryStream())
            {
                do
                {
                    result = await ws.ReceiveAsync(buffer, CancellationToken.None);
                    ms.Write(buffer.Array, buffer.Offset, result.Count);
                }
                while (!result.EndOfMessage);

                ms.Seek(0, SeekOrigin.Begin);

                using (var reader = new StreamReader(ms, Encoding.UTF8))
                    return reader.ReadToEnd();
            }
        }
    }
}
