int n = int.Parse(Console.ReadLine());
int result = 1;

for (int i = 2; i <= n; i++)
{
    result = result * i;
}

Console.WriteLine(result);