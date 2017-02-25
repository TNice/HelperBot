using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperBot.Commands
{
    //Class Child Of Program To Access The Discord Bot Instance And Implaments ICommand
    class ConnectCommand : Program, ICommand
    {
        
        public string Name
        {
            get
            {
                return "connect";
            }
        }

        public string HelpText
        {
            get
            {
                return "Connecets Bot To Discord Server";
            }
        }

        public bool isPriviledged
        {
            get
            {
                return true;
            }
        }

        public string DiscordExecute(string[] args)
        {
            return null;
        }

        public string Execute(string[] args)
        {
            bot.Connect();
            return "Connecting";
        }
    }
}
