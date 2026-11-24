string namePlayerMaxGoals = "";
int playerMaxGoals = 0;

while (true)
{
    string namePlayer = Console.ReadLine();

    if (namePlayer == "END")
    {
        break;
    }

    int countOfGoals = int.Parse(Console.ReadLine());

    if (countOfGoals > playerMaxGoals)
    {
        playerMaxGoals = countOfGoals;
        namePlayerMaxGoals = namePlayer;
    }

    if (countOfGoals >= 10)
    {
        break;
    }
}

Console.WriteLine($"{namePlayerMaxGoals} is the best player!");

if (playerMaxGoals >= 3)
{
    Console.WriteLine($"He has scored {playerMaxGoals} goals and made a hat-trick !!!");
}
else
{
    Console.WriteLine($"He has scored {playerMaxGoals} goals.");
}