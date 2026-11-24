using System.Collections.Generic;
using System.Data;

class Program
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            string[] arguments = command.Split().ToArray();
            int element;

            switch (arguments[0])
            {
                case "Insert":
                    element = int.Parse(arguments[1]);
                    int index = int.Parse(arguments[2]);
                    numbers.Insert(index, element);
                    break;
                case "Delete":
                    element = int.Parse(arguments[1]);
                    numbers.RemoveAll(e => e == element);
                    break;
            }
        }

        Console.WriteLine(string.Join(" ", numbers));
    }
}

