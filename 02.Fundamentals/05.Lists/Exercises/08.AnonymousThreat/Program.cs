using System.Globalization;

class Program
{
    static void Main()
    {
        List<string> list = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        string command;
        while ((command = Console.ReadLine()) != "3:1")
        {
            string[] arguments = command.Split();
            string action = arguments[0];

            if (action == "merge")
            {
                int startIndex = int.Parse(arguments[1]);
                int endIndex = int.Parse(arguments[2]);

                list = Merge(list, startIndex, endIndex);

            }
            else if (action == "divide")
            {
                int index = int.Parse(arguments[1]);
                int partitions = int.Parse(arguments[2]);

                list = Divide(list, index, partitions);
            }
        }
        Console.WriteLine(string.Join(" ", list));
    }

    static List<string> Divide(List<string> list, int index, int partitions)
    {
        if (partitions <= 0)
        {
            return list;
        }

        string element = list[index];

        List<string> newElement = new List<string>();

        int subLength = element.Length / partitions;
        int rest = element.Length % partitions;

        int indexNewElements = 0;

        for (int i = 0; i < partitions; i++)
        {
            string symbols = "";

            for (int j = 0; j < subLength; j++)
            {
                symbols += element[indexNewElements];
                indexNewElements++;
            }
            newElement.Add(symbols);
        }

        if (rest > 0 && newElement.Count > 0)
        {
            for (int i = indexNewElements; i < element.Length; i++)
            {
                newElement[newElement.Count - 1] += element[i];
            }
        }

        list.RemoveRange(index, 1);
        list.InsertRange(index, newElement);

        return list;
    }

    static List<string> Merge(List<string> list, int startIndex, int endIndex)
    {
        startIndex = Clamp(startIndex, 0, list.Count - 1);
        endIndex = Clamp(endIndex, 0, list.Count - 1);

        List<string> range = list.GetRange(startIndex, endIndex - startIndex + 1);
        string merged = string.Join(string.Empty, range);
        list.RemoveRange(startIndex, endIndex - startIndex + 1);
        list.Insert(startIndex, merged);

        return list;
    }

    static int Clamp(int value, int min, int max)
    {
        if (value < min)
        {
            return min;
        }
        else if (value > max)
        {
            return max;
        }

        return value;
    }
}

