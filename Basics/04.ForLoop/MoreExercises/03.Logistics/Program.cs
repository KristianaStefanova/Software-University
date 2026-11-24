int countOfTravels = int.Parse(Console.ReadLine());

int countBus = 0;
int countTruck = 0;
int countTrain = 0;
double averagePrice = 0;
int totalWeight = 0;
double averageBus = 0;
double averageTruck = 0;
double averageTrain = 0;

for (int i = 0; i < countOfTravels; i++)
{
    int weight = int.Parse(Console.ReadLine());
    
    if (weight >= 12)
    {
        countTrain += weight;
    }
    else if (weight <= 11 && weight >= 4)
    {
        countTruck += weight;
    }
    else if (weight <= 3)
    {
        countBus += weight;
    }

    totalWeight += weight;
}

averagePrice = (countBus * 200 + countTruck * 175 + countTrain * 120) / (double)totalWeight;
averageBus = (double)countBus / totalWeight * 100;
averageTruck = (double)countTruck / totalWeight * 100;
averageTrain = (double)countTrain / totalWeight * 100;

Console.WriteLine($"{averagePrice:F2}");
Console.WriteLine($"{averageBus:F2}%");
Console.WriteLine($"{averageTruck:F2}%");
Console.WriteLine($"{averageTrain:F2}%");