using System;
using System.Net.Sockets;

namespace NETWebserver.Domain
{
    public class ConnectionHandler
    {
        private TcpClient connection;

        public ConnectionHandler(TcpClient connection)
        {
            this.connection = connection;
        }

        public void HandleConnection()
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
    }
}
