using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace NETWebserver
{
    public class Response
    {
        public HTTPStatus Status { get; private set; }
        public Content Content { get; private set; }

        public Response(HTTPStatus responseStatus, Content content)
        {
            this.Status = responseStatus;
            this.Content = content;
        }

        public Response(HTTPStatus responseStatus) : this(responseStatus, null)
        {
        }

        public void Send(NetworkStream stream)
        {
            StringBuilder stringBuilder = new StringBuilder($"HTTP/1.1 {Status.ToString()}\n");
            stringBuilder.Append($"date: {DateTime.Now.ToUniversalTime().ToString("r")}\n");

            if (Content != null)
            {
                if (Content.MIMEParameter.Key != null && Content.MIMEParameter.Value != null)
                    stringBuilder.Append($"content-type: {Content.Type}; {Content.MIMEParameter.Key}={Content.MIMEParameter.Value}\n");
                else
                    stringBuilder.Append($"content-type: {Content.Type}\n");
                stringBuilder.Append($"content-length: {Content.Bytes.Length}\n\n");
                stringBuilder.Append($"{Content.Encoding.GetString(Content.Bytes)}\n");
            }

            byte[] buffer = Encoding.UTF8.GetBytes(stringBuilder.ToString());
            stream.Write(buffer, 0, buffer.Length);
        }
    }
}
