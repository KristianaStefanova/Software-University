int n = int.Parse(Console.ReadLine());

int counterp1 = 0;
int counterp2 = 0;
int counterp3 = 0;
double PercentP1 = 0.0;
double PercentP2 = 0.0;
double PercentP3 = 0.0;

for (int i = 0; i < n; i++)
{
    int currentNum = int.Parse(Console.ReadLine());

    if (currentNum % 4 == 0)
    {
        counterp3++;
    }
    else if (currentNum % 3 == 0)
    {
        counterp2++;
    }
    if (currentNum % 2 == 0)
    {
        counterp1++;
    }
}
PercentP3 = (double)counterp3 / n * 100;
PercentP2 = (double)counterp2 / n * 100;
PercentP1 = (double)counterp1 / n * 100;

Console.WriteLine($"{PercentP1:F2}");
Console.WriteLine($"{PercentP2:F2}");
Console.WriteLine($"{PercentP3:F2}");