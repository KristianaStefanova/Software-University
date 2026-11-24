using System.ComponentModel;

class Program
{
    static void Main()
    {
        List<int> targets = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        string command;

        while ((command = Console.ReadLine()) != "End")
        {
            string[] arguments = command.Split(' ');

            string action = arguments[0];

            int index;

            switch (action)
            {
                case "Shoot":
                    index = int.Parse(arguments[1]);
                    int power = int.Parse(arguments[2]);
                    Shoot(targets, index, power);
                    break;

                case "Add":
                    index = int.Parse(arguments[1]);
                    int value = int.Parse(arguments[2]);
                    Add(targets, index, value);

                    break;

                case "Strike":
                    index = int.Parse(arguments[1]);
                    int radius = int.Parse(arguments[2]);
                    Strike(targets, index, radius);

                    break;
            }
        }

        Console.WriteLine(string.Join("|", targets));
    }

    static void Strike(List<int> targets, int index, int radius)
    {
        if (index - radius < 0 || index + radius > targets.Count - 1)
        {
            Console.WriteLine("Strike missed!");

            return;
        }
       
        List<int> removedTargets = targets.GetRange(index - radius, radius * 2 + 1);
        int range = removedTargets.Count;

        targets.RemoveRange(index - radius, range);
    }


    static void Add(List<int> targets, int index, int value)
    {
        if (index < 0 || index > targets.Count - 1)
        {
            Console.WriteLine("Invalid placement!");

            return;
        }
        
        targets.Insert(index, value);
    }

    static void Shoot(List<int> targets, int index, int power)
    {
        if (index < 0 || index > targets.Count - 1)
        {
            return;
        }

        targets[index] -= power;

        if (targets[index] <= 0)
        {
            targets.RemoveAt(index);
        }
    }
}

