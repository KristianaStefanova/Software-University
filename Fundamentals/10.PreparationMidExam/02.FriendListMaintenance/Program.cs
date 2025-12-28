class Program
{
    static void Main()
    {
        string[] friends = Console.ReadLine()
            .Split(", ")
            .ToArray();

        string command;
        int counterBlacklisted = 0;
        int counterLostNames = 0;
        while ((command = Console.ReadLine()) != "Report")
        {
            string[] arguments = command.Split();

            switch (arguments[0])
            {
                case "Blacklist":
                    counterLostNames = Blacklist(friends, arguments[1], counterBlacklisted);
                    break;
                case "Error":
                    counterLostNames = Error(friends, int.Parse(arguments[1]), counterLostNames);
                    break;
                case "Change":
                    Change(friends, int.Parse(arguments[1]), arguments[2]);
                    break;
            }
        }

        Console.WriteLine($"Blacklisted names: {counterBlacklisted}");
        Console.WriteLine($"Lost names: {counterLostNames}");
        Console.WriteLine(string.Join(" ", friends));
    }

    static void Change(string[] friends, int index, string newName)
    {
        if (index >= 0 && index < friends.Length)
        {
            string name = friends[index];
            friends[index] = newName;

            Console.WriteLine($"{name} changed his username to {newName}");
        }
    }

    static int Error(string[] friends, int index, int counterLostNames)
    {
        if (index > 0 && index < friends.Length)
        {
            if (friends[index] != "Blacklisted" && friends[index] != "Lost")
            {
                counterLostNames++;
                string name = friends[index];
                Console.WriteLine($"{name} was lost due to an error.");
                friends[index] = "Lost";

                return counterLostNames;
            }
        }

        return counterLostNames;
    }

    static int Blacklist(string[] friends, string name, int counterBlacklisted)
    {
        if (friends.Contains(name))
        {
            int index = 0;
            for (int i = 0; i < friends.Length; i++)
            {
                if (friends[i] == name)
                {
                    index = i;

                }
            }

            friends[index] = "Blacklist";
            counterBlacklisted++;

            Console.WriteLine($"{name} was blacklisted.");

            return counterBlacklisted;

        }

        Console.WriteLine($"{name} was not found.");

        return counterBlacklisted;
    }
}

