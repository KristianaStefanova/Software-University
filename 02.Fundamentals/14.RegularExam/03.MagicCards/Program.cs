
class Program
{
    static void Main()
    {
        List<string> list = Console.ReadLine()
            .Split(":")
            .ToList();

        List<string> currentList = new List<string>();

        string command;
        while ((command = Console.ReadLine()) != "Ready")
        {
            string[] arguments = command.Split();

            switch (arguments[0])
            {
                case "Add":
                    if (list.Contains(arguments[1]))
                    {
                        currentList.Add(arguments[1]);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                        continue;
                    }

                    break;
                case "Insert":
                    int index = int.Parse(arguments[2]);

                    if ((list.Contains(arguments[1]) && (index >= 0 && index < currentList.Count)))
                    {
                        currentList.Insert(index, arguments[1]);
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                        continue;
                    }

                    break;
                case "Remove":
                    if (currentList.Contains(arguments[1]))
                    {
                        currentList.Remove(arguments[1]);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                        continue;
                    }

                    break;
                case "Swap":
                    string firstCard = arguments[1];
                    string secondCard = arguments[2];
                    int index1 = currentList.IndexOf(firstCard);
                    int index2 = currentList.IndexOf(secondCard);

                    string temp = firstCard;
                    currentList[index1] = secondCard;
                    currentList[index2] = temp;

                    break;
                case "Shuffle":
                    currentList.Reverse();

                    break;
            }
        }

        Console.WriteLine(string.Join(" ", currentList));
    }
}

