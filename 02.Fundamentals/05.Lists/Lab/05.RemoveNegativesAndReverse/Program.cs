class Program
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine()
            .Split(" ",StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Reverse()
            .ToList();

        numbers.RemoveAll(n => n < 0);

        if (numbers.Count == 0)
        {
            Console.WriteLine("empty");
        }
        else
        {
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

