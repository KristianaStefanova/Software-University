int n = int.Parse(Console.ReadLine());

int oddSum = 0;
int evenSum = 0;

for (int i = 0; i < n; i++)
{
    int x = int.Parse(Console.ReadLine());
    if (i % 2 == 0)
    {
        oddSum += x;
    }
    else
    {
        evenSum += x;
    }
}

if (oddSum == evenSum)
{
    Console.WriteLine("Yes");
    Console.WriteLine($"Sum = {oddSum}");
}
else  
{
    int diff = Math.Abs(oddSum - evenSum);
    Console.WriteLine("No");
    Console.WriteLine($"Diff = {diff}");
}