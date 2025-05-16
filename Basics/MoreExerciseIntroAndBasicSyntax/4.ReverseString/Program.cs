class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        var stringReverse = new string(charArray);
        Console.WriteLine(stringReverse);
    }
}

