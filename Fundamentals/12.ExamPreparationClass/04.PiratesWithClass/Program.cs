namespace _04.PiratesWithClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<City> citiesMap = new List<City>();

            string cities = null;
            while ((cities = Console.ReadLine()) != "Sail")
            {
                string[] arguments = cities.Split("||", StringSplitOptions.RemoveEmptyEntries);
                string nameCity = arguments[0];
                int population = int.Parse(arguments[1]);
                int gold = int.Parse(arguments[2]);

                City city = citiesMap.Find(c => c.Name == nameCity);

                bool shouldAdd = false;

                if (city == null)
                {
                    city = new City();
                    city.Name = nameCity;
                    shouldAdd = true;
                }

                city.Population += population;
                city.Gold += gold;

                if (shouldAdd)
                {
                    citiesMap.Add(city);
                }
            }

            string events = null;
            while ((events = Console.ReadLine()) != "End")
            {
                string[] arguments = events.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string action = arguments[0];
                string cityName = arguments[1];

                City city = citiesMap.Find(c => c.Name == cityName);

                switch (action)
                {
                    case "Plunder":
                        int population = int.Parse(arguments[2]);
                        int gold = int.Parse(arguments[3]);

                        city.Population -= population;
                        city.Gold -= gold;

                        Console.WriteLine($"{cityName} plundered! {gold} gold stolen, {population} citizens killed.");

                        if (city.Population <= 0 || city.Gold <= 0)
                        {
                            citiesMap.Remove(city);
                            Console.WriteLine($"{cityName} has been wiped off the map!");
                        }
                        break;
                    case "Prosper":
                        gold = int.Parse(arguments[2]);

                        if (gold < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                            continue;
                        }

                        city.Gold += gold;

                        Console.WriteLine($"{gold} gold added to the city treasury. {cityName} now has {city.Gold} gold.");
                        break;
                }
            }

            if (citiesMap.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {citiesMap.Count} wealthy settlements to go to:");
                foreach (City city in citiesMap)
                {
                    Console.WriteLine($"{city.Name} -> Population: {city.Population} citizens, Gold: {city.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }

    class City
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }
    }
}
