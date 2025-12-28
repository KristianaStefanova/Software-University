class Program
{
    static void Main()
    {
        string word;

        while ((word = Console.ReadLine()) != "end")
        {
            string reversedWord = string.Join("", word.ToCharArray().Reverse());
            Console.WriteLine($"{word} = {reversedWord}");
        }
    }
}

