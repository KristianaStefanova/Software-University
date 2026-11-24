class Program
{
    static void Main()
    {
        string[] numbers = Console.ReadLine()
            .Split("|")
            .ToArray();

        List<string> symbols = ExtractSymbols(numbers);

        Console.WriteLine(string.Join(" ",symbols));

    }

    private static List<string> ExtractSymbols(string[] numbersString)
    {
        List<string> result = new List<string>();

        for (int i = numbersString.Length - 1; i >= 0; i--)
        {
            string[] array = numbersString[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

            result.AddRange(array);
        }
        return result;
    }
}

