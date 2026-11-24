class Program
{
    static void Main(string[] args)
    {
        int startingYields = int.Parse(Console.ReadLine());

        const int minProfit = 100;
        const int dailyForWorkers = 26;
        const int dailyDecreacementProduction = 10;

        int days = 0;
        int totalAmount = 0;
        int production = startingYields;


        while (production >= minProfit)
        {
            startingYields = production;
            days++;
            startingYields -= dailyForWorkers;
            totalAmount += startingYields;
            production -= dailyDecreacementProduction;
        }

        totalAmount -= dailyForWorkers;

        if (totalAmount < 0)
        {
            totalAmount = 0;
        }

        Console.WriteLine(days);
        Console.WriteLine(totalAmount);
    }
}

