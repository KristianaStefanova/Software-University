int n = int.Parse(Console.ReadLine());
int firstSum = 0;
int secondSum = 0;

for (int i = 0; i < n; i++)
{
    int x = int.Parse(Console.ReadLine());
    firstSum = firstSum + x;
}
for (int j = 0; j < n; j++)
{
    int y = int.Parse(Console.ReadLine());
    secondSum = secondSum + y;
}
if (firstSum == secondSum)
{
    Console.WriteLine("Yes");
    Console.WriteLine($"Sum = {firstSum}");
}
else
{
    int diff = Math.Abs(firstSum - secondSum);
    Console.WriteLine("No");
    Console.WriteLine($"{diff}");
}