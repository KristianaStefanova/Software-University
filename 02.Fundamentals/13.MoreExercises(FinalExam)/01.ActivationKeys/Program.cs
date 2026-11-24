class Program
{
    static void Main()
    {
        string activationKey = Console.ReadLine();

        string instruction = null;
        while ((instruction = Console.ReadLine()) != "Generate")
        {
            string[] arguments = instruction.Split(">>>", StringSplitOptions.RemoveEmptyEntries);
            string action = arguments[0];
            string subStr = null;

            switch (action)
            {
                case "Contains":
                    string substring = arguments[1];

                    if (activationKey.Contains(substring))
                    {
                        Console.WriteLine($"{activationKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine($"Substring not found!");
                    }

                    break;

                case "Flip":
                    string size = arguments[1];
                    int startIndex = int.Parse(arguments[2]);
                    int endIndex = int.Parse(arguments[3]);

                    string beforeStr = activationKey.Substring(0, startIndex);
                    string afterStr = activationKey.Substring(endIndex);
                    if (size[0] == 'U')
                    {

                        subStr = activationKey.Substring(startIndex, endIndex - startIndex).ToUpper();

                    }
                    else
                    {
                        subStr = activationKey.Substring(startIndex, endIndex - startIndex).ToLower();
                    }

                    activationKey = beforeStr + subStr + afterStr;
                    Console.WriteLine(activationKey);

                    break;

                case "Slice":
                    startIndex = int.Parse(arguments[1]);
                    endIndex = int.Parse(arguments[2]);

                    activationKey = activationKey.Remove(startIndex, endIndex - startIndex);

                    Console.WriteLine(activationKey);

                    break;
            }
        }

        Console.WriteLine($"Your activation key is: {activationKey}");
    }
}

