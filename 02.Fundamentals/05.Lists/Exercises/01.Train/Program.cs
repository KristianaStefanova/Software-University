class Program
{
    static void Main()
    {
        List<int> wagons = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        int maxCapacity = int.Parse(Console.ReadLine());

        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            string[] arguments = command.Split().ToArray();

            if (arguments[0] == "Add")
            {
                int numOfPassengers = int.Parse(arguments[1]);
                wagons.Add(numOfPassengers);
            }

            if (arguments.Length == 1)
            {
                int passengers = int.Parse(arguments[0]);

                for (int i = 0; i < wagons.Count; i++)
                {
                    if (wagons[i] + passengers <= maxCapacity)
                    {
                        wagons[i] += passengers;
                        break;
                    }
                }
            }
        }

        Console.WriteLine(string.Join(" ", wagons));

    }
}

