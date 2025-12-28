class Program
{
    static void Main()
    {
        string[] bannedWords = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries); 
        string text = Console.ReadLine();

        foreach (string bannedWord in bannedWords)
        {
            if (text.Contains(bannedWord))
            {
                string replacementWithAsterisks = new string('*', bannedWord.Length);
                text = text.Replace(bannedWord, replacementWithAsterisks);
            } 
        }

        Console.WriteLine(text);
    }
}

