class Program
{
    static void Main()
    {
        double energy = double.Parse(Console.ReadLine());

        int counterMountain = 0;
        int pieces = 0;
        bool isReached = false;
        int neededPieces = 3;

        string command;

        while ((command = Console.ReadLine()) != "Journey ends here!")
        {
            switch (command)
            {
                case "mountain":
                    double mountainPoints = 10;
                    energy -= mountainPoints;
                    counterMountain++;

                    if (counterMountain == 3)
                    {
                        counterMountain = 0;
                        pieces++;

                        if (pieces == neededPieces)
                        {
                            Console.WriteLine($"The character reached the legendary artifact with {energy:F2} energy left.");
                            isReached = true;

                            return;
                        }
                    }

                    break;

                case "desert":
                    double desertPoints = 15;
                    energy -= desertPoints;
                    break;

                case "forest":
                    double forestPoints = 7;
                    energy += forestPoints;
                    break;
            }

            if (energy <= 0)
            {
                Console.WriteLine("The character is too exhausted to carry on with the journey.");

                return;
            }
        }

        Console.WriteLine($"The character could not find all the pieces and needs {neededPieces - pieces} more to complete the legendary artifact.");
    }
}

