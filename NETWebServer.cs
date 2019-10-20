using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using NETWebserver.Domain;

namespace NETWebserver
{
    public class NETWebServer
    {
        public static void Main(params String[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, 80);
            listener.Start();

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Task.Run(() => new ConnectionHandler(client).HandleConnection());
            }
        }
    }
}
