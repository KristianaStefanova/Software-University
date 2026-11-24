int number = int.Parse(Console.ReadLine());

int sum = 0;
int maxDiff = 0;
int diff = 0;
int counter = 0;
int lastSum = 0;

for (int i = 0; i < number; i++)
{
    int firstNum = int.Parse(Console.ReadLine());
    int secondNum = int.Parse(Console.ReadLine());
    counter++;

    sum = firstNum + secondNum;

    if (sum != lastSum && counter != 1)
    {
        diff = Math.Abs(sum - lastSum);
        if (diff > maxDiff)
        {
            maxDiff = diff;
        }
    }

    lastSum = sum;
}

if (maxDiff == 0)
{
    Console.WriteLine($"Yes, value={lastSum}");
}
else
{
    Console.WriteLine($"No, maxdiff={maxDiff}");
}
