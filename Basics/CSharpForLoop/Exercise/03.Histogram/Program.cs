int number = int.Parse(Console.ReadLine());
int counterP1 = 0;
int counterP2 = 0;
int counterP3 = 0;
int counterP4 = 0;
int counterP5 = 0;

for (int i = 0; i < number; i++)
{
    int currentNumber = int.Parse(Console.ReadLine());

    if (currentNumber < 200)
    {
        counterP1++;
    }
    else if (currentNumber >= 200 && currentNumber < 400)
    {
        counterP2++;
    }
    else if (currentNumber >= 400 && currentNumber < 600)
    {
        counterP3++;
    }
    else if (currentNumber >= 600 && currentNumber < 800)
    {
        counterP4++;
    }
    else if (currentNumber >= 800)
    {
        counterP5++;
    }
    
}
double percentsP1 = (double)counterP1 / number * 100;
double percentsP2 = (double)counterP2 / number * 100;
double percentsP3 = (double)counterP3 / number * 100;
double percentsP4 = (double)counterP4 / number * 100;
double percentsP5 = (double)counterP5 / number * 100;

Console.WriteLine($"{percentsP1:F2}%");
Console.WriteLine($"{percentsP2:F2}%");
Console.WriteLine($"{percentsP3:F2}%");
Console.WriteLine($"{percentsP4:F2}%");
Console.WriteLine($"{percentsP5:F2}%");
