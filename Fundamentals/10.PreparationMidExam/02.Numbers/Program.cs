using System.ComponentModel;
using System.Text;

class Program
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        string command;
        while ((command = Console.ReadLine()) != "Finish")
        {
            string[] arguments = command.Split();
            string action = arguments[0];
            int value = int.Parse(arguments[1]);

            switch (action)
            {
                case "Add":
                    Add(value, numbers);
                    break;

                case "Remove":
                    Remove(value, numbers);
                    break;

                case "Replace":
                    int replacement = int.Parse(arguments[2]);
                    Replace(value, replacement, numbers);
                    break;

                case "Collapse":
                    Collapse(value, numbers);
                    break;
            }
        }

        Console.WriteLine(string.Join(" ", numbers));
    }

    static void Collapse(int value, List<int> numbers)
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] < value)
            {
                numbers.Remove(numbers[i]);
                i--;
            }
        }
    }

    static void Replace(int value, int replacement, List<int> numbers)
    {
        if (numbers.Contains(value))
        {
            int index = numbers.IndexOf(value);
            numbers[index] = replacement;
        }
    }

    static void Remove(int value, List<int> numbers)
    {
        if (numbers.Contains(value))
        {
            numbers.Remove(value);
        }
    }
    static void Add(int value, List<int> numbers)
    {
        numbers.Add(value);
    }
}

