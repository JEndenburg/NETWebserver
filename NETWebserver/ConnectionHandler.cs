using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace NETWebserver
{
    public class ConnectionHandler
    {
        private TcpClient connection;

        private ConnectionHandler(TcpClient connection)
        {
            this.connection = connection;
        }

        private void HandleConnection()
        {
            NetworkStream stream = connection.GetStream();
            Request request = GetRequest(stream, connection.ReceiveBufferSize);

            string responseText = "Hi!😃\nThis seems to work fine!";
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            byte[] responseBytes = encoding.GetBytes(responseText);

            Response response = new Response(HTTPStatus.OK, new Content(MIMEType.PlainText, new System.Collections.Generic.KeyValuePair<string, string>("charset", "utf-8"), responseBytes, encoding));

            response.Send(stream);
            stream.Close();
            connection.Close();
        }

        private Request GetRequest(NetworkStream stream, int bufferLength)
        {
            byte[] buffer = new byte[bufferLength];
            stream.Read(buffer, 0, bufferLength);
            return new RequestReader().ReadRequest(buffer);
        }

        public static void Main(params String[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, 80);
            listener.Start();

            while(true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Task.Run(() => new ConnectionHandler(client).HandleConnection());
            }
        }
    }
}
