class Program
{
    static void Main()
    {
        int counter = int.Parse(Console.ReadLine());
        int sum = 0;

        for (int i = 0; i < counter; i++)
        {
            char ch = char.Parse(Console.ReadLine());
            sum += (int)ch;
        }

        Console.WriteLine($"The sum equals: {sum}");
    }
}

