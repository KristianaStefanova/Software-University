using System;
using System.ComponentModel;

class Program
{
    static void Main()
    {
        List<string> list = Console.ReadLine()
            .Split(", ")
            .ToList();

        int countOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfCommands; i++)
        {
            string[] command = Console.ReadLine().Split(", ").ToArray();

            switch (command[0])
            {
                case "Add":
                    Add(list, command[1]);
                    break;

                case "Remove":
                    Remove(list, command[1]);
                    break;

                case "Remove At":
                    RemoveAt(list, int.Parse(command[1]));
                    break;

                case "Insert":
                    Insert(list, int.Parse(command[1]), command[2]);
                    break;
            }
        }

        Console.WriteLine(string.Join(", ", list));
    }

    private static void Insert(List<string> list, int index, string nameCard)
    {
        if (index < 0 || index >= list.Count)
        {
            Console.WriteLine("Index out of range");

            return;
        }

        if (list.Contains(nameCard))
        {
            Console.WriteLine("Card is already added");

            return;
        }

        list.Insert(index, nameCard);

        Console.WriteLine("Card successfully added");
    }

    private static void RemoveAt(List<string> list, int index)
    {
        if (index < 0 || index >= list.Count)
        {
            Console.WriteLine("Index out of range");

            return;
        }
        list.RemoveAt(index);

        Console.WriteLine("Card successfully removed");
    }
    private static void Remove(List<string> list, string nameCard)
    {
        foreach (var c in list)
        {
            if (c == nameCard)
            {
                list.Remove(nameCard);
                Console.WriteLine("Card successfully removed");

                return;
            }
        }

        Console.WriteLine("Card not found");
    }

    private static void Add(List<string> list, string nameCard)
    {
        if (list.Contains(nameCard))
        {
            Console.WriteLine("Card is already in the deck");

            return;
        }

        list.Add(nameCard);

        Console.WriteLine("Card successfully added");
    }
}

