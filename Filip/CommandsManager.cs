using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Filip
{
    static class CommandsManager
    {
        public static Dictionary<string, Command> AllCommands = new Dictionary<string, Command>();
        public static List<string> BasicCommnads = new List<string>() { "KROK", "VLEVO" };

        public static void AddCommand(string text)
        {
            try
            {
                Command command = new Command(text);
                AllCommands.Add(command.Name, command);
                ExecuteCommand(command);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Chybná syntaxe", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public static void ExecuteCommand(string commandName)
        {
            try
            {
                if (AllCommands.Keys.Contains(commandName))
                {
                    ExecuteCommand(AllCommands[commandName]);
                }
                else if (BasicCommnads.Contains(commandName))
                {
                    ExecuteBasicCommand(commandName);
                }
                else
                {
                    throw new Exception(String.Format("Příkaz \"{0}\" nebyl nalezen.", commandName));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Chyba spuštení", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void ExecuteCommand(Command command)
        {
            try
            {
                for (int i = 0; i < command.Content.Length; i++)
                {
                    if (BasicCommnads.Contains(command.Content[i]))
                    {
                        ExecuteBasicCommand(command.Content[i]);
                    }
                    else if (AllCommands.Keys.Contains(command.Content[i]))
                    {
                        ExecuteCommand(AllCommands[command.Content[i]]);
                    }
                    else
                    {
                        throw new Exception(String.Format("Příkaz \"{0}\" nebyl nalezen.", command.Content[i]));
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Chyba spuštení", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static void ExecuteBasicCommand(string commandName)
        {
            switch (commandName)
            {
                case "KROK":
                    Controller.FilipRobot.Step();
                    break;
                case "VLEVO":
                    Controller.FilipRobot.Turn();
                    break;
                default:
                    throw new Exception(String.Format("Základní příkaz \"{0}\" nebyl nalezen.", commandName));
            }
        }

        public static List<string> GetAllCommandsNames()
        {
            List<string> names = new List<string>();
            names.AddRange(BasicCommnads);
            names.AddRange(AllCommands.Keys.ToList());
            return names;
        }
    }
}
