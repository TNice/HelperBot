using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotWithConsoleCommands
{
    //Class Implaments ICommand
    class ClearCommand : ICommand
    {
        public string Name
        {
            get
            {
                return "clear";
            }
        }

        public string HelpText
        {
            get
            {
                return "Clears Console";
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
            Console.Clear();
            Console.Write($"Music Discord Bot v. {Settings.Default.Version}\n");
            return null;
        }
    }
}
