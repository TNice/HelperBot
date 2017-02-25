using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Audio;
using Discord.Commands;

namespace HelperBot
{
    class DiscordBot
    {     
        //Declare Client
        public DiscordClient client = new DiscordClient();

        char commandPrefix = '`'; 

        public DiscordBot()
        {

            //Executed When Bot Connects To Server   
            client.ServerAvailable += (s, e) =>
            {
               //bool add = true;
                Console.WriteLine($"Bot Connected To {e.Server.Name}");
                Console.Write("~");
                //Add Server To Server List If Not In
                Program.serverList.Add(e.Server);
            };

            //Executes When Server Is Not Avalible (Not Sure If Working)
            client.ServerUnavailable += (s, e) =>
            {
                Console.WriteLine($"Bot Disconnected From {e.Server.Name}");
                Console.Write("~");
            };

            client.MessageReceived += async (s, e) =>
            {
                if (e.Message.IsAuthor) return;

                Console.Write($"{e.User.Name} ({e.User.Id}): {e.Message.Text}\n~");
              
                //Check for command prefix
                if (e.Message.Text[0] == commandPrefix)
                {
                    //Break Command Into Parts        
                    Program.lastUser = e.User;
                    Program.lastChannel = e.Channel;  
                    if (e.User.VoiceChannel != null)
                    {
                        Program.voiceChannel = e.User.VoiceChannel;
                    }   
                    string rawText = e.Message.Text.Remove(0, 1).ToLower();
                    List<string> commandParts = rawText.Split(' ').ToList<string>();
                    string command = commandParts[0];
                    commandParts.RemoveAt(0);
                    string[] args = commandParts.ToArray<string>();

                    //Make Sure Command Is Valid And Can Be Run Through Discord
                    try
                    {
                        string result = Program.registry.DiscordExecute(command, args);
                    }
                    catch (CommandNotFoundException)
                    {
                        await e.Channel.SendMessage("Command Not Found");
                    }
                    catch (ArgumentException)
                    {
                        await e.Channel.SendMessage("Command Only Accessable To Console");
                    }
                }
            }; 

            //Executed When User Joins Server
            client.UserJoined += async (s, e) =>
            {
                //Search For an anouncement channel
                Channel anounce = e.Server.FindChannels("anouncement").FirstOrDefault();
                if (anounce == null)
                {
                    await e.Server.DefaultChannel.SendMessage($"Welcome {e.User} To {e.Server.Name}");
                }
                else
                {
                   await anounce.SendMessage($"Welcome {e.User} To {e.Server.Name}");
                }
            };
            //Executes When User Leaves Server
            client.UserLeft += async (s, e) =>
            {
                //Search For an anouncement channel
                Channel anounce = e.Server.FindChannels("anouncement").FirstOrDefault();
                if (anounce == null)
                {
                    await e.Server.DefaultChannel.SendMessage($"{e.User} Has Decided To Leave {e.Server.Name}");
                }
                else
                {
                    await anounce.SendMessage($"{e.User} Has Decided To Leave {e.Server.Name}");
                }
            };
            //Executes When User Is Banned
            client.UserBanned += async (s, e) =>
            {
                //Search For an anouncement channel
                Channel anounce = e.Server.FindChannels("anouncement").FirstOrDefault();
                if (anounce == null)
                {
                    await e.Server.DefaultChannel.SendMessage($"{e.User} Banned From {e.Server.Name}");
                }
                else
                {
                    await anounce.SendMessage($"{e.User} Banned From {e.Server.Name}");
                }
            };
            //Executes When User Is UnBanned
            client.UserUnbanned += async (s, e) =>
            {
                //Search For an anouncement channel
                Channel anounce = e.Server.FindChannels("anouncement").FirstOrDefault();
                if (anounce == null)
                {
                    await e.Server.DefaultChannel.SendMessage($"{e.User} Has Been Unbanned From {e.Server.Name}");
                }
                else
                {
                    await anounce.SendMessage($"{e.User} Has Been Unbanned From {e.Server.Name}");
                }
            };
           
           

        }
        
        public async void Greet(string name, string p, Channel channel)
        {
            await channel.SendMessage($"{name} greets {p}");
        }

        public void Connect()
        {
            client.Connect(Settings.Default.Token, TokenType.Bot);
        }

        public void Disconnect()
        {
            Program.serverList.Clear();
            client.Disconnect();
        }


        public async void Help(List<ICommand> commands, User user = null, Channel channel = null)
        {
            if(user == null)
            {
                string helpMessage = "```\n";
                foreach(ICommand c in commands)
                {
                    helpMessage += $"{c.Name}: {c.HelpText}\n";
                }
                helpMessage += "```";
                await channel.SendMessage(helpMessage);
            }
        }
    }
}
