int number = int.Parse(Console.ReadLine());

int sumEven = 0;
int sumOdd = 0;

for (int i = 1; i <= number; i++)
{
    int currentNumber = int.Parse(Console.ReadLine());

    if (i % 2 == 0)
    {
        sumEven += currentNumber;
    }
    else
    {
        sumOdd += currentNumber;
    }
}
if (sumEven == sumOdd)
{
    Console.WriteLine("Yes");
    Console.WriteLine($"Sum = {sumEven}");
}
else
{
    int diff = Math.Abs(sumEven - sumOdd);
    Console.WriteLine("No");
    Console.WriteLine($"Diff = {diff}");
}
