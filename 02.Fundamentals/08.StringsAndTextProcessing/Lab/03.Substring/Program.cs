class Program
{
    static void Main()
    {
        string key = Console.ReadLine();
        string word = Console.ReadLine();

        while (word.Contains(key))
        {
            int startIndex = word.IndexOf(key);
            word = word.Remove(startIndex, key.Length);
        }

        Console.WriteLine(word);
    }
}

