int n = int.Parse(Console.ReadLine());

int sum = 0;
int diff = 0;
int maxDiff = int.MinValue;

for (int i = 0; i < n; i++)
{
    int lastSum = sum;
    sum = 0;
    int x = int.Parse(Console.ReadLine());  
    int y = int.Parse(Console.ReadLine());
    sum = x + y;
    if (i != 0)
    {
        diff = Math.Abs(sum - lastSum);
    }
    if(diff > maxDiff)
    {
        maxDiff = diff;
    }
      
}

if (diff == 0)
{
    Console.WriteLine("Yes");
    Console.WriteLine($"value={sum}");
}
else
{
    Console.WriteLine("No");
    Console.WriteLine($"maxdiff={maxDiff}");
}

