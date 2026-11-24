int coinCounter = 0;
double change = double.Parse(Console.ReadLine());
int levaInStotinki = (int)Math.Round(change * 100);

while (levaInStotinki > 0)
{
    if (levaInStotinki >= 200)
    {
        coinCounter++;
        levaInStotinki -= 200;
    }
    else if (levaInStotinki >= 100)
    {
        coinCounter++;
        levaInStotinki -= 100;
    }
    else if (levaInStotinki >= 50)
    {
        coinCounter++;
        levaInStotinki -= 50;
    }
    else if (levaInStotinki >= 20)
    {
        coinCounter++;
        levaInStotinki -= 20;
    }
    else if (levaInStotinki >= 10)
    {
        coinCounter++;
        levaInStotinki -= 10;
    }
    else if (levaInStotinki >= 5)
    {
        coinCounter++;
        levaInStotinki -= 5;
    }
    else if (levaInStotinki >= 2)
    {
        coinCounter++;
        levaInStotinki -= 2;
    }
    else if (levaInStotinki >= 1)
    {
        coinCounter++;
        levaInStotinki -= 1;
    }
}

Console.WriteLine(coinCounter);
