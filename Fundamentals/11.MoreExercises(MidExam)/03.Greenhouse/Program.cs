class Program
{
    static void Main()
    {
        List<string> list = Console.ReadLine()
            .Split(" & ")
            .ToList();

        string command;
        while ((command = Console.ReadLine()) != "Collect!")
        {
            string[] arguments = command.Split();

            switch (arguments[0])
            {
                case "Plant":
                    Plant(list, arguments[1]);
                    break;

                case "Transplant":
                    Transplant(list, arguments[1]);
                    break;

                case "Replace":
                    Replace(list, int.Parse(arguments[1]), int.Parse(arguments[2]));
                    break;

                case "Uproot":
                    Uproot(list, arguments[1]);
                    break;
            }
        }

        Console.WriteLine(string.Join(" | ", list));
    }

    private static void Uproot(List<string> list, string crop)
    {
        if (list.Contains(crop))
        {
            list.RemoveAll(c => c == crop);
        }
    }

    private static void Replace(List<string> list, int index1, int index2)
    {
        if ((index1 > 0 && index1 < list.Count) &&
            (index2 > 0 && index2 < list.Count))
        {
            string copyFirstIndex = list[index1];
            list[index1] = list[index2];
            list[index2] = copyFirstIndex;
        }
    }
    private static void Transplant(List<string> list, string crop)
    {
        if (list.Contains(crop))
        {
            list.Remove(crop);
            list.Add(crop);
        }
    }
    private static void Plant(List<string> list, string crop)
    {
        if (list.Contains(crop))
        {
            return;
        }

        list.Insert(0, crop);
    }
}

