class Program
{
    static void Main(string[] args)
    {
        decimal pounds = decimal.Parse(Console.ReadLine());
        decimal rate = 1.31m;
        decimal result = pounds * rate;

        Console.WriteLine($"{result:f3}");
    }
}

