using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main()
    {
        Dictionary<string, int> foodMap = new Dictionary<string, int>();

        int soldFood = 0;

        string command = String.Empty;

        while ((command = Console.ReadLine()) != "Complete")
        {
            string[] arguments = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string action = arguments[0];
            int quantity = int.Parse(arguments[1]);
            string food = arguments[2];

            switch (action)
            {
                case "Receive":
                    foodMap = Recieve(quantity, food, foodMap);
                    break;
                case "Sell":
                    if (!foodMap.ContainsKey(food))
                    {
                        Console.WriteLine($"You do not have any {food}.");
                        continue;
                    }

                    soldFood += quantity;

                    if (quantity > foodMap[food])
                    {
                        int originalQuantity = foodMap[food];

                        foodMap[food] = 0;
                        foodMap.Remove(food);

                        Console.WriteLine($"There aren't enough {food}. You sold the last {originalQuantity} of them.");
                    }
                    else
                    {
                        foodMap[food] -= quantity;
                        Console.WriteLine($"You sold {quantity} {food}.");

                        if (foodMap[food] == 0)
                        {
                            foodMap.Remove(food);
                        }
                    }

                    break;
            }
        }

        foreach (KeyValuePair<string, int> food in foodMap)
        {
            Console.WriteLine($"{food.Key}: {food.Value}");
        }

        Console.WriteLine($"All sold: {soldFood} goods");
    }

    static Dictionary<string, int> Recieve(int quantity, string food, Dictionary<string, int> foodMap)
    {
        if (quantity < 0)
        {
            return foodMap;
        }

        if (!foodMap.ContainsKey(food))
        {
            foodMap.Add(food, 0);
        }

        foodMap[food] += quantity;

        return foodMap;
    }
}

