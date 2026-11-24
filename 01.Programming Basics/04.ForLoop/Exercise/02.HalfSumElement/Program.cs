using System.Runtime.ConstrainedExecution;

int num = int.Parse(Console.ReadLine());

int sum = 0;
int maxNum = int.MinValue;

for (int i = 0; i < num; i++)
{
    int currentNum = int.Parse(Console.ReadLine());
    sum += currentNum;
    if (currentNum > maxNum)
    {
        maxNum = currentNum;
    }
}
int finalSum = sum - maxNum;


if (finalSum == maxNum)
{
    Console.WriteLine("Yes");
    Console.WriteLine($"Sum = {finalSum}");
}
else
{
    int diff = Math.Abs(finalSum - maxNum);
    Console.WriteLine("No");
    Console.WriteLine($"Diff = {diff}");
}