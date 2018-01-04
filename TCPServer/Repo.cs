using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPServer
{
    public static class Repo
    {
        //add commands that the swith in the clienthandler knows about to the list
        public static List<string> Commands = new List<string>() { "Goodbye"};
    }
}
