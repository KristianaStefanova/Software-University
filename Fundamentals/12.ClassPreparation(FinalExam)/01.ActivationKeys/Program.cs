using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main()
    {
        string message = Console.ReadLine();

        string input = null;
        while ((input = Console.ReadLine()) != "Reveal")
        {
            string[] arguments = input.Split(":|:", StringSplitOptions.RemoveEmptyEntries);

            string action = arguments[0];
            string substring;
            switch (action)
            {
                case "InsertSpace":
                    int index = int.Parse(arguments[1]);
                    message = InsertSpace(index, message);
                    break;
                case "Reverse":
                    substring = arguments[1];
                    message = ReverseStr(substring, message);
                    break;
                case "ChangeAll":
                    substring = arguments[1];
                    string replacement = arguments[2];
                    message = ChangeAll(substring, replacement, message);
                    break;
            }
        }
        Console.WriteLine($"You have a new text message: {message}");
    }

    static string ChangeAll(string substring, string replacement, string message)
    {
        message = message.Replace(substring, replacement);

        Console.WriteLine(message);

        return message;
    }

    static string ReverseStr(string substring, string message)
    {
        int index = message.IndexOf(substring);

        if (index == -1)
        {
            Console.WriteLine("error");
            return message;
        }
        
         string beforeSubstring = message.Substring(0, index);
         string afterSubstring = message.Substring(index + substring.Length);

         char[] reversedChars = substring.Reverse().ToArray();
         string reversedString = new string(reversedChars);
         string result = beforeSubstring + afterSubstring + reversedString;

         Console.WriteLine(result);

        return result;
    }

    static string InsertSpace(int index, string message)
    {
        message = message.Insert(index, " ");
        Console.WriteLine(message);
        return message;
    }
}

