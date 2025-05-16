int countEggs1 = int.Parse(Console.ReadLine());
int countEggs2 = int.Parse(Console.ReadLine());

while (true)
{
    string action = Console.ReadLine();

    if (action == "End")
    {
        Console.WriteLine($"Player one has {countEggs1} eggs left.");
        Console.WriteLine($"Player two has {countEggs2} eggs left.");
        break;
    }

    if (action == "one")
    {
        countEggs2--;
        if (countEggs2 == 0)
        {
            Console.WriteLine($"Player two is out of eggs. Player one has {countEggs1} eggs left.");
            break;
        }
    }
    if (action == "two")
    {
        countEggs1--;
        if (countEggs1 == 0)
        {
            Console.WriteLine($"Player one is out of eggs. Player two has {countEggs2} eggs left.");

            break;
        }
    }
}