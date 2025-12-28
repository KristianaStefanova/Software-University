class Program
{
    static void Main()
    {


        int key = int.Parse(Console.ReadLine());
        int count = int.Parse(Console.ReadLine());
        string word = string.Empty;

        for (int i = 1; i <= count; i++)
        {
            char letters = char.Parse(Console.ReadLine());
            word += (char)(letters + key);
        }

        Console.WriteLine(word);
    }
}

