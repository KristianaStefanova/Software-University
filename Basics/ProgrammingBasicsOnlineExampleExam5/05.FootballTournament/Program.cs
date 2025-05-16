string nameFootbalTeam = Console.ReadLine();
int countOfMatches = int.Parse(Console.ReadLine());

int counterW = 0;
int counterD = 0;
int counterL = 0;
int acumulatedPoints = 0;
bool noParticipation = false;

if (countOfMatches == 0)
{
    noParticipation = true;
    Console.WriteLine($"{nameFootbalTeam} hasn't played any games during this season.");
}

for (int i = 0; i < countOfMatches; i++)
{
    char result = char.Parse(Console.ReadLine());

    if (result == 'W')
    {
        counterW++;
        acumulatedPoints += 3;
    }
    else if (result == 'D')
    {
        counterD++;
        acumulatedPoints++;
    }
    else
    {
        counterL++;
    }
}

double percentW = counterW / (double)countOfMatches * 100;

if (noParticipation == false)
{
    Console.WriteLine($"{nameFootbalTeam} has won {acumulatedPoints} points during this season.");
    Console.WriteLine("Total stats:");
    Console.WriteLine($"## W: {counterW}");
    Console.WriteLine($"## D: {counterD}");
    Console.WriteLine($"## L: {counterL}");
    Console.WriteLine($"Win rate: {percentW:F2}%");
}