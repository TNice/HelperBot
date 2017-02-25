using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperBot.Commands
{
    class HelpCommand : Program, ICommand
    {
        public string Name
        {
            get
            {
                return "help";
            }
        }

        public string HelpText
        {
            get
            {
                return "Shows All Commands";
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
            if (args.Length == 0)
            {
                bot.Help(CommadHandler.commands, null, Program.lastChannel);
            }          
            else if (args[1].ToLower() == "public")
            {
                bot.Help(CommadHandler.commands, null, Program.lastChannel);
            }
            else
            {
                bot.Help(CommadHandler.commands, Program.lastUser);
            }
            return null;
        }

        public string Execute(string[] args)
        {
            string helpText = $"\n{"---Commands---", -15} {"---Info---", 30}\n";
            foreach (ICommand c in CommadHandler.commands)
            {
                helpText += $"{c.Name, -15} {c.HelpText, 30}\n";
            }

            Console.Write(helpText);
            return null;
        }
    }
}
