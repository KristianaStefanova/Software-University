class Program
{
    static void Main()
    {
        Dictionary<string, int[]> cityMap = new();

        string cities;
        while ((cities = Console.ReadLine()) != "Sail")
        {
            string[] arguments = cities.Split("||", StringSplitOptions.RemoveEmptyEntries);

            string name = arguments[0];
            int population = int.Parse(arguments[1]);
            int gold = int.Parse(arguments[2]);

            if (!cityMap.ContainsKey(name))
            {
                cityMap[name] = new int[2];
            }
            cityMap[name][0] += population;
            cityMap[name][1] += gold;
        }

        string events;
        while ((events = Console.ReadLine()) != "End")
        {
            string[] arguments = events.Split("=>", StringSplitOptions.RemoveEmptyEntries);

            string action = arguments[0];
            string city;
            int gold;
            switch (action)
            {
                case "Plunder":
                    city = arguments[1];
                    int people = int.Parse(arguments[2]);
                    gold = int.Parse(arguments[3]);

                    cityMap = Plunder(city, people, gold, cityMap);
                    break;
                case "Prosper":
                    city = arguments[1];
                    gold = int.Parse(arguments[2]);
                    cityMap = Prosper(city, gold, cityMap);
                    break;
            }
        }

        if (cityMap.Count > 0)
        {
            Console.WriteLine($"Ahoy, Captain! There are {cityMap.Count} wealthy settlements to go to:");
            foreach (KeyValuePair<string, int[]> city in cityMap)
            {
                Console.WriteLine($"{city.Key} -> Population: {city.Value[0]} citizens, Gold: {city.Value[1]} kg");
            }
        }
        else
        {
            Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
        }
    }

    static Dictionary<string, int[]> Prosper(string city, int gold, Dictionary<string, int[]> cityMap)
    {
        if (gold < 0)
        {
            Console.WriteLine("Gold added cannot be a negative number!");
            return cityMap;
        }

        cityMap[city][1] += gold;
        Console.WriteLine($"{gold} gold added to the city treasury. {city} now has {cityMap[city][1]} gold.");
        return cityMap;
    }

    static Dictionary<string, int[]> Plunder(string city, int people, int gold, Dictionary<string, int[]> cityMap)
    {
        cityMap[city][0] -= people;
        cityMap[city][1] -= gold;
        Console.WriteLine($"{city} plundered! {gold} gold stolen, {people} citizens killed.");

        if (cityMap[city][0] <= 0 || cityMap[city][1] <= 0)
        {
            Console.WriteLine($"{city} has been wiped off the map!");
            cityMap.Remove(city);
        }

        return cityMap;
    }
}

