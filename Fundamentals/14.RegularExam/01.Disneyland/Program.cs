class Program
{
    static void Main(string[] args)
    {
        double journey = double.Parse(Console.ReadLine());

        int countOfMonths = int.Parse(Console.ReadLine());

        double savedMoney = 0.0;

        for (int i = 1; i <= countOfMonths; i++)
        {

            if (i % 4 == 0)
            {
                savedMoney += savedMoney * 0.25;
            }

            if (i % 2 != 0 && i != 1)
            {
                savedMoney -= savedMoney * 0.16;
            }

            savedMoney += journey * 0.25;
        }

        if (savedMoney >= journey)
        {
            double moneyLeft = savedMoney - journey;
            Console.WriteLine($"Bravo! You can go to Disneyland and you will have {moneyLeft:F2}lv. for souvenirs.");
        }
        else
        {
            double neededMoney = journey - savedMoney;
            Console.WriteLine($"Sorry. You need {neededMoney:F2}lv. more.");
        }
    }
}

