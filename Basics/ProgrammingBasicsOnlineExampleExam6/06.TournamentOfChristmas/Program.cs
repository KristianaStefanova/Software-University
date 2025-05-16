int days = int.Parse(Console.ReadLine());

int counterVictories = 0;
int counterLosts = 0;
double pricePerDay = 0.0;
int victoryDay = 0;
int noVictoryDay = 0;
double finalPrice = 0.0;

for (int i = 1; i <= days; i++)
{
    while (true)
    {
        string sport = Console.ReadLine();

        if (sport == "Finish")
        {
            break;
        }
        string winOrLose = Console.ReadLine();

        if (winOrLose == "win")
        {
            pricePerDay += 20;
            counterVictories++;
        }
        else if (winOrLose == "lose")
        {
            counterLosts++;
        }
    }

    if (counterVictories > counterLosts)
    {
        victoryDay++;
        pricePerDay = pricePerDay * 1.1;
    }
    else
    {
        noVictoryDay++;
    }

    finalPrice += pricePerDay;
    pricePerDay = 0;
    counterVictories = 0;
    counterLosts = 0; ;
}

if (victoryDay > noVictoryDay)
{
    finalPrice *= 1.2;
    Console.WriteLine($"You won the tournament! Total raised money: {finalPrice:F2}");
}
else
{
    Console.WriteLine($"You lost the tournament! Total raised money: {finalPrice:F2}");
}