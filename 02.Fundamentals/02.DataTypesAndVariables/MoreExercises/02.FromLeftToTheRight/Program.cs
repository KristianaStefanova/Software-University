class Program
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        for (var i = 0; i < n; i++)
        {
            var array = Console.ReadLine()
                .Split(" ")
                .Select(long.Parse)
                .ToArray();

            var leftNumber = array[0];
            var rightNumber = array[1];

            Console.WriteLine(leftNumber > rightNumber ? SumDigits(leftNumber) : SumDigits(rightNumber));
        }
    }
    private static int SumDigits(long number)
    {
        var sum = 0;

        while (number != 0)
        {
            sum += (int)(number % 10);
            number /= 10;
        }

        return Math.Abs(sum);
    }
}

