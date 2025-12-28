class Program
{
    static void Main()
    {
        int countOfCities = int.Parse(Console.ReadLine());

        decimal totalProfit = 0.0m;

        for (int i = 1; i <= countOfCities; i++)
        {
            string nameCity = Console.ReadLine();
            decimal income = decimal.Parse(Console.ReadLine());
            decimal expenses = decimal.Parse(Console.ReadLine());

            decimal profit = 0.0m;


            if (i % 3 == 0 && i % 5 != 0)
            {
                expenses += expenses / 2;
            }

            if (i % 5 == 0)
            {
                income *= 0.9m;
            }

            profit = income - expenses;
            totalProfit += profit;

            Console.WriteLine($"In {nameCity} Burger Bus earned {profit:F2} leva.");
        }

        Console.WriteLine($"Burger Bus total profit: {totalProfit:F2} leva.");
    }
}

