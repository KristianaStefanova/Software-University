using System.Threading.Channels;

class Program
{
    static void Main()
    {
        double currentBalance = double.Parse(Console.ReadLine());
        double priceOutFallForth = 39.99;
        double priceCSOG = 15.99;
        double ZplinterZell = 19.99;
        double HonoredTwo = 59.99;
        double RoverWatch = 29.99;
        double priceRoverWatchOriginsEdition = 39.99;
        double totalSpendedMoney = 0;

        string command;
        while ((command = Console.ReadLine()) != "Game Time")
        {
            string nameGame = command;

            switch (nameGame)
            {
                case "OutFall 4":
                    if (priceOutFallForth <= currentBalance)
                    {
                        totalSpendedMoney += priceOutFallForth;
                        currentBalance -= priceOutFallForth;
                        Console.WriteLine($"Bought {nameGame}");
                        if (currentBalance == 0)
                        {
                            Console.WriteLine("Out of money!");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    break;
                case "CS: OG":
                    if (priceCSOG <= currentBalance)
                    {
                        totalSpendedMoney += priceCSOG;
                        currentBalance -= priceCSOG;
                        Console.WriteLine($"Bought {nameGame}");
                        if (currentBalance == 0)
                        {
                            Console.WriteLine("Out of money!");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    break;
                case "Zplinter Zell":
                    if (ZplinterZell <= currentBalance)
                    {
                        totalSpendedMoney += ZplinterZell;
                        currentBalance -= ZplinterZell;
                        Console.WriteLine($"Bought {nameGame}");
                        if (currentBalance == 0)
                        {
                            Console.WriteLine("Out of money!");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    break;
                case "Honored 2":
                    if (HonoredTwo <= currentBalance)
                    {
                        totalSpendedMoney += HonoredTwo;
                        currentBalance -= HonoredTwo;
                        Console.WriteLine($"Bought {nameGame}");
                        if (currentBalance == 0)
                        {
                            Console.WriteLine("Out of money!");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    break;
                case "RoverWatch":
                    if (RoverWatch <= currentBalance)
                    {
                        totalSpendedMoney += RoverWatch;
                        currentBalance -= RoverWatch;
                        Console.WriteLine($"Bought {nameGame}");
                        if (currentBalance == 0)
                        {
                            Console.WriteLine("Out of money!");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    break;
                case "RoverWatch Origins Edition":
                    if (priceRoverWatchOriginsEdition <= currentBalance)
                    {
                        totalSpendedMoney += priceRoverWatchOriginsEdition;
                        currentBalance -= priceRoverWatchOriginsEdition;
                        Console.WriteLine($"Bought {nameGame}");
                        if (currentBalance == 0)
                        {
                            Console.WriteLine("Out of money!");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    break;
                default:
                    Console.WriteLine("Not Found");
                    break;
            }
        }
        Console.WriteLine($"Total spent: ${totalSpendedMoney:F2}. Remaining: ${currentBalance:F2}");
    }
}

