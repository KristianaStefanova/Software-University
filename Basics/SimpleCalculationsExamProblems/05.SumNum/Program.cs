int n = int.Parse(Console.ReadLine());

int sumNum = 0;
int maxNum = int.MinValue;

for (int i = 0; i < n; i++)
{
    int y = int.Parse(Console.ReadLine());

    sumNum += y;

    if (y > maxNum)
    {
     maxNum = y;
     
    }
}

if (maxNum == (sumNum - maxNum))
{
    sumNum -= maxNum;
    Console.WriteLine("Yes");
    Console.WriteLine($"Sum = {sumNum}");
}
else 
{
    sumNum -= maxNum;
    int diff = Math.Abs(sumNum - maxNum);
    Console.WriteLine("No");
    Console.WriteLine($"Diff = {diff}");
}