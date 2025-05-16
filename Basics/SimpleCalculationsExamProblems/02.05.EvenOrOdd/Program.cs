int n = int.Parse(Console.ReadLine());

double maxNumOdd = double.MinValue;
double maxNumEven = double.MinValue;
double minNumOdd = double.MaxValue;
double minNumEven = double.MaxValue;
double sumEven = 0;
double sumOdd = 0;

for (int i = 1; i <= n; i++)
{
    double x = double.Parse(Console.ReadLine());
    if (i % 2 == 0)
    {
        sumEven += x;
        if (x> maxNumEven)
        {
           maxNumEven = x;
        }
        if (x < minNumEven)
        {
            minNumEven = x;

        }
    }
    else
    {
        sumOdd += x;
        if (x > maxNumOdd)
        {
            maxNumOdd = x;
        }
        if (x < minNumOdd)
        {
            minNumOdd = x;
        }
    }
}

Console.WriteLine($"OddSum={sumOdd}");
Console.WriteLine($"OddMin={minNumOdd}");
Console.WriteLine($"OddMax={maxNumOdd}");
Console.WriteLine($"EvenSum={sumEven}");

if (minNumEven == double.MaxValue)
{
    Console.WriteLine("No");
}
else
{
    Console.WriteLine($"EvenMin={minNumEven}");
}

if (maxNumEven == double.MinValue)
{
    Console.WriteLine("No");
}
else
{
    Console.WriteLine($"EvenMax{maxNumEven}");
}