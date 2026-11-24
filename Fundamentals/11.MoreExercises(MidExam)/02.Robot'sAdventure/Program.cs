using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        List<int> list = Console.ReadLine()
            .Split("|")
            .Select(int.Parse)
            .ToList();

        int points = 0;
        string command;

        while ((command = Console.ReadLine()) != "Adventure over")
        {
            string[] arguments = command.Split("$");
            string[] action = arguments[0].Split().ToArray();


            if (action[0] == "Step")
            {
                switch (action[1])
                {
                    case "Backward":
                        points += StepBackward(list, int.Parse(arguments[1]), int.Parse(arguments[2]));
                        break;
                    case "Forward":
                        points += StepForward(list, int.Parse(arguments[1]), int.Parse(arguments[2]));
                        break;
                }
            }
            else
            {
                switch (action[0])
                {
                    case "Double":
                        DoubleIndex(list, int.Parse(action[1]));
                        break;
                    case "Switch":
                        list.Reverse();
                        break;
                }

            }
        }

        Console.WriteLine(string.Join(" - ", list));
        Console.WriteLine($"Robo finished the adventure with {points} items!");
    }

    private static void DoubleIndex(List<int> list, int index)
    {
        if (index >= 0 && index < list.Count)
        {
            list[index] *= 2;
        }
    }
    private static int StepForward(List<int> list, int index, int steps)
    {
        int points = 0;
        int counter = 0;

        if (index >= 0 && index < list.Count)
        {
            while (steps > 0)
            {
                if (index == list.Count - 1 && counter == 0)
                {
                    index = 0;
                }
                else if (counter > 0)
                {
                    index = 0;
                }
                else if (counter == 0 && index > 0)
                {
                    index = index + 1;
                }

                for (int i = index; i < list.Count; i++)
                {
                    steps--;
                    counter++;
                    if (steps == 0)
                    {
                        points = list[i];
                        list[i] = 0;
                        return points;
                    }
                }
            }
        }

        return points;
    }

    static int StepBackward(List<int> list, int index, int steps)
    {
        int points = 0;
        int counter = 0;
        if (index >= 0 && index < list.Count)
        {
            while (steps > 0)
            {
                if (counter > 0)
                {
                    index = list.Count - 1;
                }
                else if (counter == 0 && index > 0)
                {
                    index = index - 1;
                }

                if (index == 0 && counter == 0)
                {
                    index = list.Count - 1;
                }

                for (int i = index; i >= 0; i--)
                {
                    steps--;
                    counter++;
                    if (steps == 0)
                    {
                        points = list[i];
                        list[i] = 0;
                        return points;

                    }
                }
            }
        }

        return points;
    }
}
