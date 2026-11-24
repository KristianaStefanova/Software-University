class Program
{
    static void Main(string[] args)
    {
        char alphabeticSymbol = char.Parse(Console.ReadLine());
        bool isUpper = char.IsUpper(alphabeticSymbol);

        if (isUpper)
        {
            Console.WriteLine("upper-case");
        }
        else
        {
            Console.WriteLine("lower-case");
        }
    }
}

