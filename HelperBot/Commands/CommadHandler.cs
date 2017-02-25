using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HelperBot
{
    
    class CommadHandler
    {
       //Makes a list of all commands that implament ICommand interface
       public static List<ICommand> commands = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.GetInterfaces().Contains(typeof(ICommand)) && x.GetConstructor(Type.EmptyTypes) != null)
                .Select(x => Activator.CreateInstance(x) as ICommand).ToList<ICommand>();

        //Registers Commands With Command Registry
        public static void RegisterCommands()
        {
           
            foreach (ICommand command in commands)
            {
                Program.registry.RegisterCommand(command);
            }
        }
    }
}
