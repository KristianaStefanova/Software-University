class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());
        decimal result = 0;

        for (int i = 0; i < count; i++)
        {
            decimal number = decimal.Parse(Console.ReadLine());

            result += (decimal)number;
        }

        Console.WriteLine($"{result}");
    }
}

