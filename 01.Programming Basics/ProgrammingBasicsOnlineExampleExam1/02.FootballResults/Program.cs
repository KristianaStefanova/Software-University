string resultFirstMatch = Console.ReadLine();
string resultSecondMatch = Console.ReadLine();
string resulThirdMatch = Console.ReadLine();

int counterWins = 0;
int counterDrawns = 0;
int counterLoses = 0;

int firstResultHome = int.Parse(resultFirstMatch[0].ToString());
int firstResultAway = int.Parse(resultFirstMatch[2].ToString());

if (firstResultHome > firstResultAway)
{
    counterWins++;
}
else if (firstResultHome == firstResultAway)
{
    counterDrawns++;
}
else if (firstResultHome < firstResultAway)
{
    counterLoses++;
}

int secondResultHome = int.Parse(resultSecondMatch[0].ToString());
int secondResultAway = int.Parse(resultSecondMatch[2].ToString());

if (secondResultHome > secondResultAway)
{
    counterWins++;
}
else if (secondResultHome == secondResultAway)
{
    counterDrawns++;
}
else if (secondResultHome < secondResultAway)
{
    counterLoses++;
}

int thirdResultHome = int.Parse(resulThirdMatch[0].ToString());
int thirdResultAway = int.Parse(resulThirdMatch[2].ToString());


if (thirdResultHome > thirdResultAway)
{
    counterWins++;
}
else if (thirdResultHome == thirdResultAway)
{
    counterDrawns++;
}
else if (thirdResultHome < thirdResultAway)
{
    counterLoses++;
}
Console.WriteLine($"Team won {counterWins} games.");
Console.WriteLine($"Team lost {counterLoses} games.");
Console.WriteLine($"Drawn games: {counterDrawns}");
