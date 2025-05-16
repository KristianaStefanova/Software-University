int n = int.Parse(Console.ReadLine());
int counterP1 = 0;
int counterP2 = 0;
int counterP3 = 0;
int counterP4 = 0;
int counterP5 = 0;
int counterP6 = 0;

for (int i = 0; i < n; i++)
{
    int currentNum = int.Parse(Console.ReadLine());

    if (currentNum < 200)
    {
        counterP1++;
    }
    else if (currentNum >= 200 && currentNum < 400)
    {
        counterP2++;
    }
    else if (currentNum >= 400 && currentNum < 600)
    {
        counterP3++;
    }
    else if (currentNum >= 600 && currentNum < 800)
    {
        counterP5++;
    }
    else if (currentNum >= 800)
    {
        counterP6++;
    }
}
double percentP1 = (double)counterP1 / n * 100;
double percentP2 = (double)counterP2 / n * 100;
double percentP3 = (double)counterP3 / n * 100;
double percentP4 = (double)counterP4 / n * 100;
double percentP5 = (double)counterP5 / n * 100;
double percentP6 = (double)counterP6 / n * 100;

Console.WriteLine($"{percentP1:F2}"); 
Console.WriteLine($"{percentP2:F2}"); 
Console.WriteLine($"{percentP3:F2}"); 
Console.WriteLine($"{percentP4:F2}"); 
Console.WriteLine($"{percentP5:F2}"); 
Console.WriteLine($"{percentP6:F2}"); 
