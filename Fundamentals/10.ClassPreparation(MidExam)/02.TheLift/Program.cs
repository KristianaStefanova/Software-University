class Program
{
    static void Main()
    {
        int queue = int.Parse(Console.ReadLine());

        List<int> stateLift = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        int maxCapacity = 4;

        for (int i = 0; i < stateLift.Count; i++)
        {
            int currentWagonCount = stateLift[i];

            for (int j = currentWagonCount; j < maxCapacity; j++)
            {
                stateLift[i]++;
                queue--;
                if (queue == 0)
                {
                    int sum = stateLift.Sum();

                    if (sum < stateLift.Count * maxCapacity)
                    {
                        Console.WriteLine($"The lift has empty spots!\n{string.Join(" ", stateLift)}");
                        return;
                    }
                }
            }
        }

        if (queue > 0)
        {
            Console.WriteLine($"There isn't enough space! {queue} people in a queue!");
        }

        Console.WriteLine(string.Join(" ", stateLift));
    }
}

