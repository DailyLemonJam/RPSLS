using System;
using System.Collections.Generic;
using ConsoleTables;

namespace RPSLS
{
    class Table
    {
        private ConsoleTable table;

        public Table(string[] args) // R Sc L P Sp
        {
            FillTable(args);
        }

        private void FillTable(string[] args)
        {
            var temp = new List<string> { "User / PC" };
            MakeHead(ref temp, args);
            MakeFirst(ref temp, args);
            for (int i = 0; i < args.Length - 1; i++)
            {
                temp.RemoveAt(0);
                temp.Insert(0, temp[^1]);
                temp.RemoveAt(temp.Count - 1);
                temp.Insert(0, args[i + 1]);
                table.AddRow(temp.ToArray());
            }
            temp.Clear();
        }

        private void MakeFirst(ref List<String> temp, string[] args)
        {
            temp.Add(args[0]);
            temp.Add("Draw");
            for (int k = 0; k < (args.Length - 1) / 2; k++)
            {
                temp.Add("Win");
            }
            for (int k = 0; k < (args.Length - 1) / 2; k++)
            {
                temp.Add("Lose");
            }
            table.AddRow(temp.ToArray());
        }

        private void MakeHead(ref List<String> temp, string[] args)
        {
            foreach (var elem in args)
            {
                temp.Add(elem);
            }
            table = new ConsoleTable(temp.ToArray());
            temp.Clear();
        }

        public void ShowTable()
        {
            table.Write(Format.Alternative);
        }
    }
}
