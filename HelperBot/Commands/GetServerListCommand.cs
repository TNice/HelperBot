using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace HelperBot.Commands
{
    //Class Child Of Program To Access The Discord Bot Instance And Implaments ICommand
    class GetServerListCommand : Program, ICommand
    {
        public string Name
        {
            get
            {
                return "getservers";
            }
        }

        public string HelpText
        {
            get
            {
                return "Gets List of Connected Servers";
            }
        }

        public bool isPriviledged
        {
            get
            {
                return false;
            }
        }

        public string DiscordExecute(string[] args)
        {
            return null;
        }

        public string Execute(string[] args)
        {
            Console.WriteLine("\n{0,-30} {1,15}", "Server", "Id");

            foreach (Server s in Program.serverList)
            {
                Console.WriteLine("\n{0,-30} {1, 15}", s.Name, s.Id.ToString());
            }
            return null;
        }
    }
}

