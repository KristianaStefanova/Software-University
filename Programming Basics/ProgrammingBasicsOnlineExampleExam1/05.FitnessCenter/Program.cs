int countOfClients = int.Parse(Console.ReadLine());

int counterBack = 0;
int counterChest = 0;
int counterLegs = 0;
int counterAbs = 0;
int foodCounter = 0;
int workOut = 0;
int proteinBar = 0;
int proteinShake = 0;

for (int i = 1; i <= countOfClients; i++)
{
    string whatTheyDo = Console.ReadLine();

    if (whatTheyDo == "Back")
    {
        workOut++;
        counterBack++;
    }
    else if (whatTheyDo == "Chest")
    {
        workOut++;
        counterChest++;
    }
    else if (whatTheyDo == "Legs")
    {
        workOut++;
        counterLegs++;
    }
    else if (whatTheyDo == "Abs")
    {
        workOut++;
        counterAbs++;
    }
    else if (whatTheyDo == "Protein shake")
    {
        foodCounter++;
        proteinShake++;
    }
    else if (whatTheyDo == "Protein bar")
    {
        foodCounter++;
        proteinBar++;
    }
}
double percentWorkOut = workOut / (double)countOfClients * 100;
double percentFood = foodCounter / (double)countOfClients * 100;

Console.WriteLine($"{counterBack} - back");
Console.WriteLine($"{counterChest} - chest");
Console.WriteLine($"{counterLegs} - legs");
Console.WriteLine($"{counterAbs} - abs");
Console.WriteLine($"{proteinShake} - protein shake");
Console.WriteLine($"{proteinBar} - protein bar");
Console.WriteLine($"{percentWorkOut:F2}% - work out");
Console.WriteLine($"{percentFood:F2}% - protein");
