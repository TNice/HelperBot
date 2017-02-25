using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using System.Reflection;

namespace HelperBot
{
    //Command Interface
    public interface ICommand
    {
        
        string Name { get; }

        string HelpText { get; }

        //isPrivliledged = true { Command Can Only Be Used In Console }
        bool isPriviledged { get; }

        string DiscordExecute(string[] args);

        string Execute(string[] args);
    }

    class Program
    {             
        //Make A Command Registry
        public static CommandRegistry<ICommand> registry = new CommandRegistry<ICommand>();
        public DiscordBot bot = new DiscordBot();
        public static List<Server> serverList = new List<Server>();
        public static User lastUser;
        public static Channel lastChannel;
        public static Channel voiceChannel;

        static void Main(string[] args)
        {
          
            //Register All Commands That Implament ICommand Interface
            CommadHandler.RegisterCommands();
            //Print Program Version
            Console.Write($"Music Discord Bot v. {Settings.Default.Version}\n");

            while (true)
            {
                Console.Write("~");
                //Get User Input
                string line = Console.ReadLine().ToLower();
                //Split User Input Into its Parts
                List<string> parts = line.Split(' ').ToList<string>();
                //Seperate Command From Args
                string commandName = parts[0];
                parts.RemoveAt(0);
                string[] commandArgs = parts.ToArray<string>();

                //Try To Run Command And Throw Command Not Found If No Command Found
                try
                {
                    string result = registry.Execute(commandName, commandArgs);
                    if (result != null)
                    {
                        Console.WriteLine("[{0}] {1}", commandName, result);
                    }
                }
                catch (CommandNotFoundException)
                {
                    Console.WriteLine("No Command {0}", commandName);
                }
            }
        } 
        
    }
   
}

