using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCPServer
{
    class Server
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Run();
        }

        private void Run()
        {
            TcpListener server = new TcpListener(IPAddress.Any, 12345);
            server.Start();

            while (true)
            {
                Socket client = server.AcceptSocket();
                IPEndPoint ip = (IPEndPoint)client.RemoteEndPoint;

                Console.WriteLine(ip.Address + ":" + ip.Port + " Has COnnected");
                ClientHandler handler = new ClientHandler(client);
                Thread thread = new Thread(handler.Run);
                thread.Start();
            }
        }
    }
}
