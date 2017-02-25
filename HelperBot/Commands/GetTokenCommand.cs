using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperBot.Commands
{
    class GetTokenCommand : ICommand
    {
        public string Name
        {
            get
            {
                return "gettoken";
            }
        }

        public string HelpText
        {
            get
            {
                return "Gets The Current Bot Token";
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

            return Settings.Default.Token;
        }
    }
}
