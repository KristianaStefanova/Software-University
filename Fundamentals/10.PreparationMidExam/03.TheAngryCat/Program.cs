class Program
{
    static void Main()
    {
        List<int> list = Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .ToList();

        int entryPoint = int.Parse(Console.ReadLine());
        string value = Console.ReadLine();
        int leftSum = 0;
        int rightSum = 0;

        
        for (int i = 0; i < entryPoint; i++)
        {
            if (value == "expensive")
            {
                if (list[entryPoint] <= list[i])
                {
                    leftSum += list[i];
                }
            }
            else if (value == "cheap")
            {
                if (list[entryPoint] > list[i])
                {
                    leftSum += list[i];
                }
            }
        }

        for (int i = entryPoint + 1; i < list.Count; i++)
        {
            if (value == "expensive")
            {
                if (list[entryPoint] <= list[i])
                {
                    rightSum += list[i];
                }
            }
            else if (value == "cheap")
            {
                if (list[entryPoint] > list[i])
                {
                    rightSum += list[i];
                }
            }
        }

        if (leftSum >= rightSum)
        {
            Console.WriteLine($"Left - {leftSum}");
        }
        else
        {
            Console.WriteLine($"Right - {rightSum}");
        }
    }
}

