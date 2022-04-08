using ConsoleTables;
using System;

namespace task3
{
    internal class TableGenerator
    {
        private ConsoleTable table;

        public TableGenerator(string[] args)
        {
            var number = args.Length + 1;

            var rules = new Rules(args);
            var results = rules.GetResults();
            table = new ConsoleTable("Player\\Computer");
            table.AddColumn(args);

            for (int i = 0; i < args.Length; i++)
            {
                var row = new string[number];
                row[0] = args[i];

                for (int j = 1; j < number; j++)
                {
                    row[j] = results[i, j - 1].ToString();
                }
                table.AddRow(row);

            }
        }

        public void Show()
        {
            Console.Clear();
            table.Write(Format.Alternative);
            Console.ReadKey();
        }
    }
}
