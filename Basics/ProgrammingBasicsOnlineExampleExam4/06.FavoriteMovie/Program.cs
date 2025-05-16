class Program
{
    static void Main()
    {
        string bestMovie = "";
        int bestScore = 0;
        int counter = 0;
        int totalSum = 0;
        string command;
        while ((command = Console.ReadLine()) != "STOP")
        {
            string nameMovie = command;
            counter++;
            if (counter > 7)
            {
                Console.WriteLine("The limit is reached.");
                break;
            }

            for (int i = 0; i < nameMovie.Length; i++)
            {
                char symbol = nameMovie[i];
                int intSymbol = (int)symbol;
                if (intSymbol > 57 && intSymbol < 91 && intSymbol != 32)
                {
                    intSymbol -= nameMovie.Length;
                }
                else if (intSymbol > 96 && intSymbol != 32)
                {
                    intSymbol -= 2 * nameMovie.Length;
                }
                totalSum += intSymbol;

            }

            if (bestScore < totalSum)
            {
                bestScore = totalSum;
                bestMovie = nameMovie;
            }
            totalSum = 0;
        }

        Console.WriteLine($"The best movie for you is {bestMovie} with {bestScore} ASCII sum.");
    }
}

