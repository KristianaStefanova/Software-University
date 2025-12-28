using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        string username = Console.ReadLine();

        string command = String.Empty;

        while ((command = Console.ReadLine()) != "Registration")
        {
            string[] arguments = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string action = arguments[0];

            switch (action)
            {
                case "Letters":
                    string letterCase = arguments[1];
                    username = LetterCase(letterCase, username);
                    break;
                case "Reverse":
                    int startIndex = int.Parse(arguments[1]);
                    int endIndex = int.Parse(arguments[2]);
                    Reverse(startIndex, endIndex, username);
                    break;
                case "Substring":
                    string substring = arguments[1];
                    Substring(substring, username);
                    break;
                case "Replace":
                    char letter = char.Parse(arguments[1]);
                    username = Replace(letter, username);
                    break;
                case "IsValid":
                    char symbol = char.Parse(arguments[1]);
                    IsValid(symbol, username);
                    break;
            }
        }
    }

    static void IsValid(char symbol, string username)
    {
        if (!username.Contains(symbol))
        {
            Console.WriteLine($"{symbol} must be contained in your username.");
            return;
        }

        Console.WriteLine("Valid username.");
    }

    static string Replace(char symbol, string username)
    {
        username = username.Replace(symbol, '-');
        Console.WriteLine(username);

        return username;
    }

    static void Substring(string substring, string username)
    {
        if (!username.Contains(substring))
        {
            Console.WriteLine($"The username {username} doesn't contain {substring}.");
            return;
        }

        username = username.Replace(substring, "");

        Console.WriteLine(username);
    }

    static void Reverse(int startIndex, int endIndex, string username)
    {
        if (startIndex < 0 || endIndex >= username.Length)
        {
            return;
        }

        string substring = username.Substring(startIndex, endIndex - startIndex + 1);
        char[] charArr = substring.ToCharArray();
        Array.Reverse(charArr);
            
        Console.WriteLine(charArr);
    }

    static string LetterCase(string letterCase, string username)
    {

        if (letterCase == "Lower")
        {
            username = username.ToLower();
        }
        else
        {
            username = username.ToUpper();
        }

        Console.WriteLine(username);

        return username;
    }
}

