double num = double.Parse(Console.ReadLine());

double minOdd = double.MaxValue;
double minEven = double.MaxValue;
double maxEven = double.MinValue;
double maxOdd = double.MinValue;
double sumOdd = 0;
double sumEven = 0;

for (int i = 1; i <= num; i++)
{
    double currentNum = double.Parse(Console.ReadLine());
    
    if (i % 2 != 0)
    {
        sumOdd += currentNum;
        if (currentNum < minOdd)
        {
            minOdd = currentNum;
        }
        if (currentNum > maxOdd)
        {
            maxOdd = currentNum;
        }
    }
    else if (i % 2 == 0)
    {
        sumEven += currentNum;
        if (currentNum < minEven)
        {
            minEven = currentNum;
        }
        if (currentNum > maxEven)
        {
            maxEven = currentNum;
        }
    }
}

Console.WriteLine($"OddSum={sumOdd:F2},");

if (num < 1)
{
    Console.WriteLine($"OddMin=No,");
}
else
{
Console.WriteLine($"OddMin={minOdd:F2},");
}

if (num < 1)
{
    Console.WriteLine($"OddMax=No,");
}
else
{
Console.WriteLine($"OddMax={maxOdd:F2},");
}

Console.WriteLine($"EvenSum={sumEven:F2},");

if (num <= 1)
{
    Console.WriteLine($"EvenMin=No,");
}
else
{
Console.WriteLine($"EvenMin={minEven:F2},");
}

if (num <= 1)
{
    Console.WriteLine($"EvenMax=No");
}
else
{
Console.WriteLine($"EvenMax={maxEven:F2}");
}

