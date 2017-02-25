using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperBot.Commands
{
    //Class Child Of Program To Access The Discord Bot Instance And Implaments ICommand
    class DisconnectCommand : Program, ICommand
    {
        public string Name
        {
            get
            {
                return "disconnect";
            }
        }

        public string HelpText
        {
            get
            {
                return "Disonnecets Bot From Discord Server";
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
            bot.Disconnect();
            return "Disconnecting";
        }
    }

}

