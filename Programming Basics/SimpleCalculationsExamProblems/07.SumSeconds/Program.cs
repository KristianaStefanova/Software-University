int fistAthlet = int.Parse(Console.ReadLine());
int secondAthlet = int.Parse(Console.ReadLine());
int trirdAthlet = int.Parse(Console.ReadLine());

int minutes = 0;

int seconds = fistAthlet + secondAthlet + trirdAthlet;

if (seconds <= 59)
{
    
    Console.WriteLine($"{minutes}:{seconds}");
}

else if (seconds > 59 && seconds <= 119)
{
    minutes++;
    seconds -= 60;
    if (seconds <= 9)
    {
        Console.WriteLine($"{minutes}:0{seconds}");
    }
    else
    {
        Console.WriteLine($"{minutes}:{seconds}");
    }
}
else if (seconds > 119 && seconds <= 179)
{
    minutes = 2;
    seconds -= 120;
    if (seconds <= 9)
    {
        Console.WriteLine($"{minutes}:0{seconds}");
    }
    else
    {
        Console.WriteLine($"{minutes}:{seconds}");
    }
}
else if (seconds > 179 && seconds < 239)
{
    minutes = 3;
    seconds -= 180;
    if (seconds <= 9)
    {
        Console.WriteLine($"{minutes}:0{seconds}");
    }
    else
    {
        Console.WriteLine($"{minutes}:{seconds}");
    }
}

