using System;

namespace RPSLS
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Check(ref args))
            {
                return;
            }
            SecurityGenerator sg = new(args);
            Rules rules = new(args);
            Table table = new(args);
            while (true)
            {
                int move;
                string input;
                do
                {
                    Console.Clear();
                    ShowMenu(ref args, ref sg);
                    input = Console.ReadLine();
                    if (input == "?")
                    {
                        table.ShowTable();
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (input == "0")
                    {
                        return;
                    }
                } while (!int.TryParse(input, out move) || int.Parse(input) > args.Length || int.Parse(input) < 0);
                Console.WriteLine("Your move: " + args[move - 1]);
                Console.WriteLine("Computer move: " + args[sg.GetMoveIndex()]);
                Console.WriteLine(rules.Winner(move - 1, sg.GetMoveIndex()));
                Console.WriteLine("HMAC key: " + sg.GetKey());
                Console.ReadLine();
                return;
            }
        }

        private static void ShowMenu(ref string[] args, ref SecurityGenerator sg)
        {
            Console.WriteLine("HMAC: " + sg.GetHMAC());
            Console.WriteLine("Available moves:");
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine((i + 1) + " - " + args[i]);
            }
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
            Console.Write("Enter your move: ");
        }

        private static bool Check(ref string[] args)
        {
            string ex = "Example: R P S; R P S L M.";
            if (args.Length % 2 == 0 || args.Length < 3)
            {
                Console.WriteLine("Wrong input. Amount should be odd and more or equal 3.\n" + ex);
                Console.ReadKey();
                return false;
            }
            for (int i = 0; i < args.Length; i++)
            {
                for (int j = 0; j < args.Length; j++)
                {
                    if (i != j && args[i] == args[j])
                    {
                        Console.WriteLine("Wrong input. There shouldn't be the same inputs.\n" + ex);
                        Console.ReadKey();
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
