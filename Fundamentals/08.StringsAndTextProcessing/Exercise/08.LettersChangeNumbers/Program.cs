class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        decimal result = 0;
        int alphabetPosition = 0;
        decimal totalSum = 0;

        foreach (string str in input)
        {
            char letterBefore = str[0];
            char letterAfter = str[str.Length - 1];
            ulong number = ulong.Parse(str.Substring(str[1], str[str.Length - 2]));

            if (char.IsUpper(letterBefore))
            {
                alphabetPosition = (int)letterBefore - 'A' + 1;
                result = (decimal)number / alphabetPosition;
            }
            else if (char.IsLower(letterBefore))
            {
                alphabetPosition = (int)letterBefore - 'a' + 1;
                result = (decimal)number * alphabetPosition;
            }

            if (char.IsUpper(letterAfter))
            {
                alphabetPosition = (int)letterAfter - 'A' + 1;
                result = (decimal)number - alphabetPosition;
            }
            else if (char.IsLower(letterAfter))
            {
                alphabetPosition = (int)letterAfter - 'a' + 1;
                result = (decimal)number + alphabetPosition;
            }

            totalSum += result;
        }

        Console.WriteLine($"{totalSum:F2}");
    }
}

