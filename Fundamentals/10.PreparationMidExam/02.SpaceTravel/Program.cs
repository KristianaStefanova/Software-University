using Microsoft.VisualBasic.CompilerServices;

class Program
{
    static void Main()
    {
        string[] route = Console.ReadLine()
            .Split("||")
            .ToArray();

        int fuel = int.Parse(Console.ReadLine());
        int ammunition = int.Parse(Console.ReadLine());

        for (int i = 0; i < route.Length; i++)
        {
            string[] arguments = route[i].Split();
            string action = arguments[0];

            switch (action)
            {
                case "Travel":
                    int integer = int.Parse(arguments[1]);
                    bool isReached = Travel(fuel, integer);
                    if (isReached)
                    {
                        fuel -= integer;
                    }
                    else
                    {
                        return;
                    }

                    break;
                case "Enemy":
                    int integerEnemy = int.Parse(arguments[1]);
                    bool isSave = Enemy(ammunition, fuel, integerEnemy);
                    bool escape = false;

                    if (!isSave)
                    {
                        escape = EnemyRun(ammunition, fuel, integerEnemy);
                    }

                    if (isSave)
                    {
                        ammunition -= integerEnemy;
                    }
                    else
                    {
                        if (!escape)
                        {
                            return;
                        }

                        fuel -= integerEnemy * 2;
                    }
                    break;

                case "Repair":
                    int integerRepair = int.Parse(arguments[1]);
                    Repair(ammunition, fuel, integerRepair);
                    break;

                case "Titan":
                    Console.WriteLine("You have reached Titan, all passengers are safe.");
                    break;
            }
        }
    }

    static bool EnemyRun(int ammunition, int fuel, int enemyPoints)
    {
        bool escape = false;

        if (fuel >= 2 * enemyPoints)
        {
            escape = true;
            Console.WriteLine($"An enemy with {enemyPoints} armour is outmaneuvered.");
            return escape;
        }
        else
        {
            Console.WriteLine("Mission failed.");
            return escape;
        }
    }

    private static void Repair(int ammunition, int fuel, int numberAdded)
    {
        fuel += numberAdded;
        ammunition += numberAdded * 2;

        Console.WriteLine($"Ammunitions added: {numberAdded * 2}.");
        Console.WriteLine($"Fuel added: {numberAdded}.");
    }

    static bool Enemy(int ammunition, int fuel, int enemyPoints)
    {
        bool isSave = false;

        if (ammunition >= enemyPoints)
        {
            isSave = true;
            Console.WriteLine($"An enemy with {enemyPoints} armour is defeated.");
            return isSave;
        }

        return isSave;
    }


    static bool Travel(int fuel, int lightYears)
    {
        bool isReached = false;

        if (fuel >= lightYears)
        {
            fuel -= lightYears;
            isReached = true;
            Console.WriteLine($"The spaceship travelled {lightYears} light-years.");
            return isReached;
        }
        else
        {
            Console.WriteLine("Mission failed.");
            return isReached;
        }
    }
}

