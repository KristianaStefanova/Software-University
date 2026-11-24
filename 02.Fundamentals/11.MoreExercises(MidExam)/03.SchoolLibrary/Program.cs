class Program
{
    static void Main()
    {
        List<string> books = Console.ReadLine()
            .Split("&")
            .ToList();

        string command;
        while ((command = Console.ReadLine()) != "Done")
        {
            string[] arguments = command.Split(" | ");

            switch (arguments[0])
            {
                case "Add Book":
                    if (books.Contains(arguments[1]))
                    {
                        continue;
                    }
                    books.Insert(0, arguments[1]);
                    break;

                case "Take Book":
                    if (books.Contains(arguments[1]))
                    {
                        books.Remove(arguments[1]);
                    }
                    break;

                case "Swap Books":
                    if (books.Contains(arguments[1]) && books.Contains(arguments[2]))
                    {
                        int indexFirstBook = books.IndexOf(arguments[1]);
                        int indexSecondBook = books.IndexOf(arguments[2]);
                        string copyFirstBook = books[indexFirstBook];
                        books[indexFirstBook] = books[indexSecondBook];
                        books[indexSecondBook] = copyFirstBook;
                    }
                    else
                    {
                        continue;
                    }

                    break;

                case "Insert Book":
                    if (books.Contains(arguments[1]))
                    {
                        continue;
                    }

                    books.Add(arguments[1]);

                    break;

                case "Check Book":
                    int index = int.Parse(arguments[1]);
                    if (index < 0 || index >= books.Count)
                    {
                        continue;
                    }

                    Console.WriteLine($"{books[index]}");
                    break;
            }
        }

        Console.WriteLine(string.Join(", ", books));
    }
}

