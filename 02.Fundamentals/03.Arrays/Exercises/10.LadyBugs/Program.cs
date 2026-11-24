class Program
{
    static void Main()
    {
        int fieldSize = int.Parse(Console.ReadLine());

        int[] indexesBugs = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();

        int[] fieldBugs = new int[fieldSize];

        for (int i = 0; i < indexesBugs.Length; i++)
        {
            int currentIndex = indexesBugs[i];
            if (currentIndex >= 0 && currentIndex <= fieldBugs.Length - 1)
            {
                fieldBugs[currentIndex] = 1;
            }
        }

        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            string[] arguments = command.Split();

            int index = int.Parse(arguments[0]);
            string rotation = arguments[1];
            int steps = int.Parse(arguments[2]);

            if (index < 0 || index > fieldBugs.Length - 1 || fieldBugs[index] == 0)
            {
                continue;
            }

            fieldBugs[index] = 0;

            if (rotation == "right")
            {
                int landIndex = index + steps;

                if (landIndex < 0 || landIndex > fieldBugs.Length - 1)
                {
                    continue;
                }

                if (landIndex >= 0 && landIndex <= fieldBugs.Length - 1)
                {
                    while (fieldBugs[landIndex] == 1)
                    {
                        landIndex += steps;
                        if (landIndex > fieldBugs.Length - 1)
                        {
                            break;
                        }
                    }
                }

                if (landIndex < fieldBugs.Length)
                {
                    fieldBugs[landIndex] = 1;
                }
            }
            else if (rotation == "left")
            {
                int landIndex = index - steps;

                if (landIndex < 0 || landIndex > fieldBugs.Length - 1)
                {
                    continue;
                }

                if (landIndex >= 0 && landIndex <= fieldBugs.Length - 1)
                {
                    while (fieldBugs[landIndex] == 1)
                    {
                        landIndex -= steps;
                        if (landIndex < 0)
                        {
                            break;
                        }
                    }
                }

                if (landIndex >= 0)
                {
                    fieldBugs[landIndex] = 1;
                }
            }
        }

        Console.WriteLine(string.Join(" ", fieldBugs));
    }

}

