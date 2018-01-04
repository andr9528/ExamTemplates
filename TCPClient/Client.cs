using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient
{
    public class Client
    {
        Facade facade;

        public Client(string ip, int port)
        {
            facade = new Facade(ip, port);

            RunClient();

            facade.Close();
        }

        private void RunClient()
        {
            bool running = true;

            do
            {
                Console.WriteLine("Valid (non-casesensetive) inputs are as follow...");
                Console.WriteLine(facade.GetMenu());
                Console.WriteLine("What do you wish to do?");
                string order = Console.ReadLine();

                switch (order.ToLower())
                {
                    case "goodbye":
                        Console.WriteLine(facade.Goodbye());
                        running = false;
                        break;
                    default:
                        break;
                }
            } while (running);
        }
    }
}
