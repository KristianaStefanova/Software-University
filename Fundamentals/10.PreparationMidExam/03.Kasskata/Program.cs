using System.ComponentModel;
using System.Globalization;

class Program
{
    static void Main()
    {

        Inventory heroInventory = new Inventory(Console.ReadLine()
            .Split(", ",StringSplitOptions.RemoveEmptyEntries)
            .ToList());

        string input;
        while ((input = Console.ReadLine()) != "Craft!")
        {
            string[] arguments = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
            switch (arguments[0])
            {
                case "Collect":
                    heroInventory.Collect(arguments[1]);
                    break;

                case "Drop":
                    heroInventory.Drop(arguments[1]);
                    break;

                case "Combine Items":
                    string[] combineItems = arguments[1].Split(":");
                    heroInventory.Combine(combineItems[0], combineItems[1]);
                    break;

                case "Renew":
                    heroInventory.Renew(arguments[1]);
                    break;
            }
        }

        Console.WriteLine(heroInventory.ToString());
    }
}

class Inventory
{
    public List<string> Items; // private List<string> items;

    public Inventory(List<string> initialItems)
    {
        Items = initialItems;
    }

    public void Collect(string item)
    {
        if (!Items.Contains(item))
        {
            Items.Add(item);
        }
    }

    public void Drop(string item)
    {
        if (Items.Contains(item))
        {
            Items.Remove(item);
        }
    }

    public void Combine(string oldItem, string newItem)
    {
        int oldItemIndex = Items.IndexOf(oldItem);
        if (oldItemIndex >= 0)
        {
            Items.Insert(oldItemIndex + 1, newItem);
        }
    }

    public void Renew(string item)
    {
        if (Items.Remove(item))
        {
            Items.Add(item);
        }
    }
    public override string ToString()
    {
        return string.Join(", ", Items);
    }
}