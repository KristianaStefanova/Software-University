using System.Globalization;

class Program
{
    static void Main()
    {
        char firstChar = char.Parse(Console.ReadLine());
        char secondChar = char.Parse(Console.ReadLine());

        PrintAllCharectersBetween(firstChar, secondChar);
    }

    private static void PrintAllCharectersBetween(char firstChar, char secondChar)
    {
        if (secondChar < firstChar)
        {
            char copyFirst = firstChar;
            firstChar = secondChar;
            secondChar = copyFirst;
        }

        for (int i = firstChar + 1; i < secondChar; i++)
        {
            Console.Write($"{(char)i} ");
        }
        
    }
}

