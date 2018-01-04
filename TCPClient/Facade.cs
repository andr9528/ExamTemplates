using System;
using System.IO;
using System.Net.Sockets;

namespace TCPClient
{
    internal class Facade
    {
        private string ip;
        private int port;

        TcpClient serverSocket;
        NetworkStream stream;
        StreamWriter write;
        StreamReader read;

        public Facade(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
            Connect();
        }

        private void Connect()
        {
            if (serverSocket == null)
            {
                serverSocket = new TcpClient(ip, port);
                stream = serverSocket.GetStream();
                read = new StreamReader(stream);
                write = new StreamWriter(stream)
                {
                    AutoFlush = true
                };
            }
        }
        public void Close()
        {
            write.Close();
            read.Close();
            stream.Close();
            serverSocket.Close();
            serverSocket = null;
        }

        public string Goodbye()
        {
            MessageToServer("goodbye");
            return ListenToServer();
        }
        public string GetMenu()
        {
            MessageToServer("menu");
            return ListenToServer();

        }
        private void MessageToServer(string message)
        {
            write.WriteLine(message);
        }
        private string ListenToServer()
        {
            string output = "";
            try
            {
                while (read.Peek() >= 0)
                {
                    output += read.ReadLine() + '\n';
                }

                return output;
            }
            catch
            {
                return null;
            }
        }
    }
}