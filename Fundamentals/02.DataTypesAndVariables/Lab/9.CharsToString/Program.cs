class Program
{
    static void Main()
    {
        char first = char.Parse(Console.ReadLine());
        char second = char.Parse(Console.ReadLine());
        char third = char.Parse(Console.ReadLine());
        string result = $"{first}{second}{third}"; 
        Console.WriteLine(result);
    }
}

