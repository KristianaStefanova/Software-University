using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        int result = Multiply(input[0], input[1]);

        Console.WriteLine(result);
    }

    static int Multiply(string first, string second)
    {
        int biggerString = Math.Max(first.Length, second.Length);

        int result = 0;

        for (int i = 0; i < biggerString; i++)
        {
            if (i < first.Length && i < second.Length)
            {
                result += first[i] * second[i];
            }
            else if (i < first.Length)
            {
                result += first[i];
            }
            else if (i < second.Length)
            {
                result += second[i];
            }
        }

        return result;
    }
}

