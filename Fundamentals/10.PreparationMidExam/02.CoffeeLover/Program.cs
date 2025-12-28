using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

class Program
{
    static void Main()
    {
        List<string> list = Console.ReadLine().Split().ToList();

        int countOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfCommands; i++)
        {
            List<string> command = Console.ReadLine().Split().ToList();

            string action = command[0];

            switch (command[0])
            {
                case "Include":
                    Include(command[1], list);
                    break;
                case "Remove":
                    Remove(command[1], int.Parse(command[2]), list);
                    break;
                case "Prefer":
                    Prefer(int.Parse(command[1]), int.Parse(command[2]), list);
                    break;
                case "Reverse":
                    list = Reverse(list);
                    break;
            }
        }

        Console.WriteLine($"Coffees");
        Console.WriteLine();
        Console.WriteLine(string.Join(" ", list));
    }

    private static List<string> Reverse(List<string> list)
    {
        List<string> reversedList = new List<string>();
        for (int i = list.Count - 1; i >= 0; i--)
        {
            reversedList.Add(list[i]);
        }

        return reversedList;
    }

    private static void Prefer(int index1, int index2, List<string> list)
    {
        if (index1 < 0 || index2 >= list.Count)
        {
            return;
        }

        string copyFirstIndex = list[index1];
        list[index1] = list[index2];
        list[index2] = copyFirstIndex;
    }

    private static void Remove(string firstOrLast, int numberOfCoffees, List<string> list)
    {
        if (numberOfCoffees > list.Count)
        {
            return;
        }

        int index = 0;

        if (firstOrLast == "first")
        {
            index = 0;
            list.RemoveRange(index, numberOfCoffees);
        }
        else
        {
            index = list.Count - 1;
            list.RemoveRange(index - numberOfCoffees + 1, numberOfCoffees);
        }
    }

    private static void Include(string nameCoffee, List<string> list)
    {
        list.Add(nameCoffee);
    }
}

