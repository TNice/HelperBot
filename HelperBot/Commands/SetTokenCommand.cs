using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperBot.Commands
{
    class SetTokenCommand : ICommand
    {
        public string Name
        {
            get
            {
                return "settoken";
            }
        }

        public string HelpText
        {
            get
            {
                return "Sets The Current Bot Token";
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

            Settings.Default.Token = args[0];
            return Settings.Default.Token;
                    
        }
    }
}
