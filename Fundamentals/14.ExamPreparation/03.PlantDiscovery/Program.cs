using System.Numerics;

class Program
{
    static void Main()
    {
        Dictionary<string, Plant> plants = new Dictionary<string, Plant>();

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string[] infoPlants = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);

            string namePlant = infoPlants[0];
            int rarity = int.Parse(infoPlants[1]);

            if (plants.ContainsKey(namePlant))
            {
                plants[namePlant].Rarity = rarity;
            }
            else
            {
                plants[namePlant] = new Plant { Rarity = rarity };
            }
        }

        string command = String.Empty;

        while ((command = Console.ReadLine()) != "Exhibition")
        {
            string[] arguments = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

            string[] leftPart = arguments[0].Split(": ", StringSplitOptions.RemoveEmptyEntries);
            string action = leftPart[0];
            string namePlant = leftPart[1];

            if (!plants.ContainsKey(namePlant))
            {
                Console.WriteLine("error");
                continue;
            }
            switch (action)
            {
                case "Rate":
                    double rating = double.Parse(arguments[1]);
                    plants[namePlant].Ratings.Add(rating);

                    break;
                case "Update":
                    int newRarity = int.Parse(arguments[1]);
                    plants[namePlant].Rarity = newRarity;

                    break;
                case "Reset":
                    plants[namePlant].Ratings.Clear();

                    break;
            }
        }
        Console.WriteLine($"Plants for the exhibition:");
        foreach (KeyValuePair<string, Plant> plant in plants)
        {
            Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {plant.Value.AverageRating():F2}");
        }
    }
    class Plant
    {
        public int Rarity { get; set; }
        public List<double> Ratings { get; set; } = new List<double>();
        public double AverageRating()
        {
            return Ratings.Count > 0
                ? Ratings.Average()
                : 0.0;
        }
    }
}

