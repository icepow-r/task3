using System;
using System.Linq;


namespace task3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            if (!CheckArgs(args))
            {
                return;
            }

            var hmac = new HmacGenerator(args);
            var table = new TableGenerator(args);
            var move = hmac.GetNewMove();
            var flag = true;
            int number;

            do
            {
                ShowMenu(args, hmac);
                var answer = Console.ReadLine();

                if (int.TryParse(answer, out number) &&
                    number >= 0 &&
                    number <= args.Length)
                {
                    flag = false;
                }
                if (answer == "?")
                {
                    table.Show();
                }
            } while (flag);

            if (number == 0)
            {
                return;
            }

            Console.WriteLine($"Your move: {args[number - 1]}");
            Console.WriteLine($"Computer move: {args[move]}");
            var rules = new Rules(args);
            Console.WriteLine(rules.CheckWinner(number - 1, move));
            Console.WriteLine("HMAC key: " + hmac.GetKey());

        }

        static bool CheckArgs(string[] args)
        {

            if (args.Length < 3)
            {
                Console.WriteLine("The number of arguments must be greater than or equal to three.");
                Console.WriteLine("For example: task3 Rock Paper Scissors");
                return false;
            }

            if (args.Length % 2 == 0)
            {
                Console.WriteLine("The number of arguments must be odd.");
                Console.WriteLine("For example: task3 Rock Paper Scissors");
                return false;
            }

            if (args.Distinct().Count() != args.Length)
            {
                Console.WriteLine("Arguments must not be repeated.");
                Console.WriteLine("For example: task3 Rock Paper Scissors");
                return false;
            }
            return true;
        }

        static void ShowMenu(string[] args, HmacGenerator hmac)
        {
            Console.Clear();
            Console.WriteLine("HMAC: " + hmac.GetMessage());
            Console.WriteLine("Available moves: ");
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(i + 1 + " - " + args[i]);
            }
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
            Console.Write("Enter your move: ");
        }
    }
}
