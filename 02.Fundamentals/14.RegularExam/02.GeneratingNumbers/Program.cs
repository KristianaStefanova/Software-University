class Program
{
    static void Main(string[] args)
    {
        List<int> list = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            List<string> arguments = command.Split().ToList();

            switch (arguments[0])
            {
                case "add":
                    List<string> toAdd = arguments;

                    toAdd.RemoveRange(0, 3);
                    List<int> integers = toAdd.Select(int.Parse).ToList();

                    list.InsertRange(0, integers);

                    break;
                case "replace":
                    int value = int.Parse(arguments[1]);
                    int replacement = int.Parse(arguments[2]);

                    if (list.Contains(value))
                    {
                        int index = list.IndexOf(value);

                        list[index] = replacement;
                    }

                    break;
            }
            switch (arguments[1])
            {
                case "greater":
                    int value = int.Parse(arguments[3]);

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] > value)
                        {
                            list.RemoveAt(i);
                            i--;
                        }
                    }

                    break;
                case "at":
                    int index = int.Parse(arguments[3]);
                    if (index >= 0 && index < list.Count)
                    {
                        list.RemoveAt(index);
                    }

                    break;
                case "even":
                    List<int> evenNum = new List<int>();

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] % 2 == 0)
                        {
                            evenNum.Add(list[i]);
                        }
                    }

                    Console.WriteLine(string.Join(" ", evenNum));

                    break;
                case "odd":
                    List<int> oddNum = new List<int>();

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] % 2 != 0)
                        {
                            oddNum.Add(list[i]);
                        }
                    }

                    Console.WriteLine(string.Join(" ", oddNum));

                    break;
            }
        }

        Console.WriteLine(string.Join(", ", list));
    }
}

