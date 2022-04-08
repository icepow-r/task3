namespace task3
{
    public class Rules
    {
        private Result[,] results;
        public enum Result
        {
            Win,
            Lose,
            Draw,
        }

        public Rules(string[] args)
        {
            var lenght = args.Length;
            results = new Result[lenght, lenght];

            var half = (lenght + 1) / 2;
            for (int i = 0; i < lenght; i++)
            {
                for (int j = i; j < i + half; j++)
                {
                    results[i, j % lenght] = Result.Lose;
                    results[i, (i - (j - i) + lenght) % lenght] = Result.Win;
                }
                results[i, i] = Result.Draw;
            }
        }

        public Result[,] GetResults() => results;

        public string CheckWinner(int player, int computer)
        {
            return results[player, computer] switch
            {
                Result.Win => "You win!",
                Result.Lose => "You lose.",
                Result.Draw => "It's a draw.",
                _ => string.Empty,
            };
        }

    }
}
