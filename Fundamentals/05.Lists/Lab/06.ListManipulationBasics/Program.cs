using System.Data;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine()
            .Split(" ",StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        string command;

        while ((command = Console.ReadLine()) != "end")
        {
            string[] arguments = command.Split();

            switch (arguments[0])
            {
                case "Add":
                {
                    int number = int.Parse(arguments[1]);
                    numbers.Add(number);
                    break;
                }
                case "Remove":
                {
                    int number = int.Parse(arguments[1]);
                    numbers.Remove(number);
                    break;
                }
                case "RemoveAt":
                {
                    int index = int.Parse(arguments[1]);
                    numbers.RemoveAt(index);
                    break;
                }
                case "Insert":
                {
                    int number = int.Parse(arguments[1]);
                    int index = int.Parse(arguments[2]);
                    numbers.Insert(index, number);
                    break;
                }
            }
        }
            
        Console.WriteLine(string.Join(" ", numbers));
    }
}

