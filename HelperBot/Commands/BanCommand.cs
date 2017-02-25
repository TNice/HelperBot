using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotWithConsoleCommands.Commands
{
    class BanCommand : Program, ICommand
    {
        public string Name
        {
            get
            {
                return "ban";
            }
        }

        public string HelpText
        {
            get
            {
                return "Ban A Person On A Server";
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
            bool serverFound = false;
            Discord.Server lServer = null;
            Discord.User lUser = null;

            string server = null;


            for (int i = 1; i < args.Length; i++)
            {
                if (i == 1)
                {
                    server = args[i];
                    continue;
                }

                server += $" {args[i]}";
            }
            
            foreach (Discord.Server serv in Program.serverList)
            {
                if (serv.Name.ToLower() == server)
                {
                    serverFound = true;
                    lServer = serv;
                    break;
                }
            }

            if (serverFound)
            {
                try
                {
                    lUser = lServer.FindUsers(args[0]).FirstOrDefault();
                }
                catch (ArgumentNullException)
                {
                    return "User Not Found";
                }

                Console.Write($"\n~ Are You Sure You Want To Ban {lUser.Name} From {lServer.Name}. \n~ This Can Only Be Undone By Useing The UnBan Command Or Unbanning In Discord! (y/n): ");
                if (Console.Read() == 'y' || Console.Read() == 'Y')
                {
                    lServer.DefaultChannel.SendMessage(lUser.Name);
                }
                else
                {
                    return "Ban Aborted!";
                }

                return "Invite Created";
                //lServer.Ban(lUser);

            }
            else return "Server Not Found";
        }
    }
}
