using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCPServer
{
    public class ClientHandler
    {
        private Socket client;
        private StreamWriter write;
        private StreamReader read;
        private IPEndPoint ip;

        public ClientHandler(Socket client)
        {
            this.client = client;
            NetworkStream stream = new NetworkStream(client);
            read = new StreamReader(stream);
            write = new StreamWriter(stream)
            {
                AutoFlush = true
            };
            ip = (IPEndPoint)client.RemoteEndPoint;
        }

        internal void Run()
        {
            while (Cummunicate()) ;

            write.Close();
            read.Close();
            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }

        private bool Cummunicate()
        {
            string message = ReadMessage();

            if (message == null)
            {
                return false;
            }

            switch (message.ToLower())
            {
                case "menu":
                    foreach (string command in Repo.Commands)
                    {
                        WriteMessage(command);
                    }
                    break;
                case "goodbye":
                    WriteMessage("Goodbye Friend");
                    return false;
                default:
                    WriteMessage("I Don't Know what to do with this message... :(");
                    break;
            }
            return true;
        }

        private void WriteMessage(string message)
        {
            write.WriteLine(message);
        }

        private string ReadMessage()
        {
            try
            {
                return read.ReadLine();
            }
            catch
            {
                return null;
            }
        }
    }
}
