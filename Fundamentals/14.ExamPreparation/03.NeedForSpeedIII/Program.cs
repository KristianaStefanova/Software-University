class Program
{
    static void Main()
    {
        Dictionary<string, List<int>> carsMap = new Dictionary<string, List<int>>();

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string[] arguments = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
            string car = arguments[0];
            int distance = int.Parse(arguments[1]);
            int fuel = int.Parse(arguments[2]);

            carsMap.Add(car, new List<int>{distance, fuel});
        }

        string command;

        while ((command = Console.ReadLine()) != "Stop")
        {
            string[] arguments = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

            string action = arguments[0];

            switch (action)
            {
                case "Drive":
                    Drive(arguments[1], int.Parse(arguments[2]), int.Parse(arguments[3]), carsMap);

                    break;
                case "Refuel":
                    Refuel(arguments[1], int.Parse(arguments[2]), carsMap);

                    break;
                case "Revert":
                    Revert(arguments[1], int.Parse(arguments[2]), carsMap);

                    break;
            }
        }

        foreach (KeyValuePair<string, List<int>> car in carsMap)
        {
            Console.WriteLine($"{car.Key} -> Mileage: {car.Value[0]} kms, Fuel in the tank: {car.Value[1]} lt.");
        }
    }
    private static void Revert(string car, int kilometers, Dictionary<string, List<int>> carsMap)
    {
        int originalKilometers = carsMap[car][0];
        carsMap[car][0] -= kilometers;

        if (carsMap[car][0] < 10000)
        {
            carsMap[car][0] = 10000;

            return;
        }

        Console.WriteLine($"{car} mileage decreased by {originalKilometers - carsMap[car][0]} kilometers");
    }

    static void Refuel(string car, int fuel, Dictionary<string, List<int>> carsMap)
    {
        int originalFuel = carsMap[car][1];

        carsMap[car][1] += fuel;

        if (carsMap[car][1] > 75)
        {
            carsMap[car][1] = 75;
        }

        Console.WriteLine($"{car} refueled with {carsMap[car][1] - originalFuel} liters");
    }

    static void Drive(string car, int distance, int fuel, Dictionary<string, List<int>> carsMap)
    {
        if (carsMap[car][1] < fuel)
        {
            Console.WriteLine($"Not enough fuel to make that ride");
        }
        else
        {
            carsMap[car][1] -= fuel;
            carsMap[car][0] += distance;
            Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

            if (carsMap[car][0] >= 100000)
            {
                Console.WriteLine($"Time to sell the {car}!");
                carsMap.Remove(car);
            }
        }
    }
}

