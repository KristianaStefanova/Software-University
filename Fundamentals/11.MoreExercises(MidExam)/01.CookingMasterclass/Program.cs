using System.Diagnostics;

class Program
{
    static void Main()
    {
        decimal budget = decimal.Parse(Console.ReadLine());
        int students = int.Parse(Console.ReadLine());
        decimal packetFlour = decimal.Parse(Console.ReadLine());
        decimal egg = decimal.Parse(Console.ReadLine());
        decimal apron = decimal.Parse(Console.ReadLine());

        decimal expenses = 0m;

        for (int i = 1; i <= students; i++)
        {
            if (i % 5 != 0)
            {
                expenses += packetFlour;
            }

            expenses += 10 * egg;
        }

        decimal totalApron = students * 1.2m;
        int roundedValue = (int)Math.Ceiling(totalApron);
        decimal increasedValue = roundedValue * apron;
        expenses += increasedValue;

        if (budget >= expenses)
        {
            Console.WriteLine($"Items purchased for {expenses:F2}$.");
        }
        else
        {
            decimal neededMoney = expenses - budget;

            Console.WriteLine($"{neededMoney:F2}$ more needed.");
        }
    }

}