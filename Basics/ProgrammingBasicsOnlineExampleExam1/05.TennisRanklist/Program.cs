int countOfTournaments = int.Parse(Console.ReadLine());
int startingPoints = int.Parse(Console.ReadLine());

int allPoints = 0;
int counterW = 0;
double averagePoints = 0;

for (int i = 0; i < countOfTournaments; i++)
{
    string round = Console.ReadLine();

    if (round == "W")
    {
        allPoints += 2000;
        counterW++;
    }
    else if (round == "F")
    {
        allPoints += 1200;
    }
    else if (round == "SF")
    {
        allPoints += 720;
    }
}
int finalPoints = allPoints + startingPoints;
averagePoints = allPoints / countOfTournaments;
double percentWinings = counterW / (double)countOfTournaments * 100;

Console.WriteLine($"Final points: {finalPoints}");
Console.WriteLine($"Average points: {Math.Floor(averagePoints)}");
Console.WriteLine($"{percentWinings:F2}%");