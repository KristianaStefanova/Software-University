using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

class Program
{
    /*
    Hawai::Cyprys-Greece
    Add Stop:7:Rome
    Remove Stop:11:16
    Switch:Hawai:Bulgaria
    Travel
     */
    static void Main()
    {
        string stops = Console.ReadLine();

        string input = null;

        while ((input = Console.ReadLine()) != "Travel")
        {
            string[] tokens = input.Split(":", StringSplitOptions.RemoveEmptyEntries);

            string action = tokens[0];

            switch (action)
            {
                case "Add Stop":
                    stops = AddStop(int.Parse(tokens[1]), tokens[2], stops);
                    PrintOutput(stops);

                    break;
                case "Remove Stop":
                    stops = RemoveStop(int.Parse(tokens[1]), int.Parse(tokens[2]), stops);
                    PrintOutput(stops);

                    break;
                case "Switch":
                    stops = SwitchStr(tokens[1], tokens[2], stops);
                    PrintOutput(stops);

                    break;
            }
        }

        Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
    }

    static void PrintOutput(string stops)
    {
        Console.WriteLine(stops);
    }

    static string SwitchStr(string oldString, string newString, string stops)
    {
        if (stops.Contains(oldString))
        {
            stops = stops.Replace(oldString, newString);
        }

        return stops;
    }
    static string RemoveStop(int startIndex, int endIndex, string stops)
    {
        if ((startIndex >= 0 && startIndex < stops.Length) && (endIndex >= 0 && endIndex < stops.Length)) // Check if startIndex is less than endIndex
        {
            stops = stops.Remove(startIndex, endIndex - startIndex + 1);
        }

        return stops;
    }

    static string AddStop(int index, string text, string stops)
    {
        if (index >= 0 && index < stops.Length)
        {
            stops = stops.Insert(index, text);
        }

        return stops;
    }
}

