int countOfTournaments = int.Parse(Console.ReadLine());
int startingPoints = int.Parse(Console.ReadLine());
int tournamentPoints = 0;
int counterVictorys = 0;

for (int i = 0; i < countOfTournaments; i++)
{
    string roundTournament = Console.ReadLine();

    if (roundTournament == "W")
    {
        counterVictorys++;
        tournamentPoints += 2000;
    }
    else if (roundTournament == "F")
    {
        tournamentPoints += 1200;
    }
    else if (roundTournament == "SF")
    {
        tournamentPoints += 720;
    }
 }
double allPointsTournament = startingPoints + tournamentPoints;
double averagePoints = tournamentPoints / countOfTournaments;
double percentVictory = (double)counterVictorys / countOfTournaments * 100;

Console.WriteLine($"Final points: {Math.Floor(allPointsTournament)}"); 
Console.WriteLine($"Average points: {Math.Floor(averagePoints)}");
Console.WriteLine($"{percentVictory:F2}%");