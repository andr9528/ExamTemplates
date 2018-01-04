using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfClient
{
    class Client
    {
        // chage the name afther the '.' when a better name is given to the service classes
        WcfService.Service1Client service = new WcfService.Service1Client();
        static void Main(string[] args)
        {
        }
    }
}
