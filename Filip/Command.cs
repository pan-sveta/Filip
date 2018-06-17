using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Filip
{
    class Command
    {
        public string Name { get; private set; }
        public string[] Content { get; private set; }

        public Command(string text)
        {
            Parse(text);
        }

        private void Parse(string text)
        {
            string[] lines = Regex.Split(text, "\r\n|\r|\n");

            if (CheckCommandExistence(lines[0]))
            {
                throw new Exception(String.Format("Chybný název příkazu! První řádek musí obsahovat unikátní jméno nikoli \"{0}\".", lines[0]));
            }

            Name = lines[0];

            if (lines[lines.Length-1]!="KONEC")
            {
                throw new Exception(String.Format("Absence ukončovacího příkazu! Poslední řádek musí obsahovat \"KONEC\" nikoli \"{0}\".", lines[lines.Length - 1]));
            }

            List<string> content = new List<string>();

            for (int i = 1; i < lines.Length-1; i++)
            {
                if (CheckCommandExistence(lines[i]))
                {
                    if (lines[i]!=String.Empty)
                    {
                        content.Add(lines[i]);
                    }
                }
                else
                {
                    throw new Exception(String.Format("Příkaz \"{0}\" na řádku {1} nexistuje.", lines[i],i+1));
                }
            }

            Content = content.ToArray();
        }

        private bool CheckCommandExistence(string command)
        {
            return CommandsManager.AllCommands.ContainsKey(command) || CommandsManager.BasicCommnads.Contains(command);
        }
    }
}
