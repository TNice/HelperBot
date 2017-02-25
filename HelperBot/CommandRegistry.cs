using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotWithConsoleCommands
{
    public class CommandRegistry<T> where T : ICommand
    {
        private Dictionary<string, T> register;

        //Creates The Register When Class Is Instantiated
        public CommandRegistry()
        {
            register = new Dictionary<string, T>();
        }

        //Adds All Commands To The Register
        public CommandRegistry(params T[] commands) : this()
        {
            foreach(T command in commands)
            {
                register.Add(command.Name, command);
            }
        }

        //Gets Command By Name
        public T GetCommand(string name)
        {
            if (register.ContainsKey(name))
            {
                return register[name];
            }
            else
            {
                throw new CommandNotFoundException(name);
            }
        }

        //Execute Command From Console
        public string Execute(string name, string[] args)
        {
            if (register.ContainsKey(name))
            {
                return register[name].Execute(args);
            }
            else
            {
                throw new CommandNotFoundException(name);
            }
        }
        //Execute Command From Discord
        public string DiscordExecute(string name, string[] args)
        {
            if (register.ContainsKey(name))
            {
                if (!register[name].isPriviledged)
                {
                    return register[name].DiscordExecute(args);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                throw new CommandNotFoundException(name);
            }
        }

        //Puts Command To Registry
        public void RegisterCommand(T command)
        {
            register.Add(command.Name, command);
        }
    }
}
