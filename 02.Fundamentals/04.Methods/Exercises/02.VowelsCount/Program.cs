

class Program
{
    static void Main()
    {
        string word = Console.ReadLine().ToLower();

        Console.WriteLine(GetCountOfVowels(word));
    }

    static int GetCountOfVowels(string? word)
    {
        int count = 0;

        foreach (char symbol in word)
        {
            if (symbol == 'a' || symbol == 'o' || symbol == 'u' || symbol == 'e' || symbol == 'i')
            {
                count++;
            }

        }

        return count;
    }
}

