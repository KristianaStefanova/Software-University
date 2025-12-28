class Program
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        bool isChanged = false;
        string command;

        while ((command = Console.ReadLine()) != "end")
        {
            string[] arguments = command.Split();

            switch (arguments[0])
            {
                case "Add":
                    {
                        int numberToAdd = int.Parse(arguments[1]);
                        numbers.Add(numberToAdd);
                        break;
                    }
                case "Remove":
                    {
                        int numberToRemove = int.Parse(arguments[1]);
                        numbers.Remove(numberToRemove);
                        break;
                    }
                case "RemoveAt":
                    {
                        int index = int.Parse(arguments[1]);
                        numbers.RemoveAt(index);
                        break;
                    }
                case "Insert":
                    {
                        int numberToInsert = int.Parse(arguments[1]);
                        int index = int.Parse(arguments[2]);
                        numbers.Insert(index, numberToInsert);
                        break;
                    }
                case "Contains":
                    {
                        int numberToCheck = int.Parse(arguments[1]);

                        if (numbers.Contains(numberToCheck))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }

                        isChanged = true;
                        break;
                    }
                case "PrintEven":
                    {
                        List<int> evenNumbers = numbers.FindAll(n => n % 2 == 0);

                        Console.WriteLine(string.Join(" ", evenNumbers));
                        isChanged = true;
                        break;
                    }
                case "PrintOdd":
                    {
                        List<int> oddNumbers = numbers.FindAll(n => n % 2 != 0);

                        Console.WriteLine(string.Join(" ", oddNumbers));
                        isChanged = true;
                        break;
                    }
                case "GetSum":
                    {
                        int sum = numbers.Sum();
                        Console.WriteLine(sum);
                        isChanged = true;
                        break;
                    }
                case "Filter":
                    {
                        string condition = arguments[1];
                        int numberFilter = int.Parse(arguments[2]);
                        List<int> filteredNumbers = new();
                        switch (condition)
                        {
                            case "<":
                                filteredNumbers = numbers.FindAll(n => n < numberFilter);
                                break;
                            case ">":
                                filteredNumbers = numbers.FindAll(n => n > numberFilter);
                                break;
                            case "<=":
                                filteredNumbers = numbers.FindAll(n => n <= numberFilter);
                                break;
                            case ">=":
                                filteredNumbers = numbers.FindAll(n => n >= numberFilter);
                                break;
                        }

                        Console.WriteLine(string.Join(" ", filteredNumbers));
                        isChanged = true;
                        break;
                    }
            }
        }

        if (!isChanged)
        {
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

