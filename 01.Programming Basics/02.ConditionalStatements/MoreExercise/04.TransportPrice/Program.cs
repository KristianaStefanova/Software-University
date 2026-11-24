int kilometers = int.Parse(Console.ReadLine());
string dayOrNight = Console.ReadLine();

double totalMoney = 0.0;

if (kilometers >= 100)
{
   totalMoney = kilometers * 0.06;
}
else if (kilometers >= 20 )
{
    totalMoney = kilometers * 0.09; 
}
else if (dayOrNight == "day")
{
    totalMoney = kilometers * 0.79 + 0.70;
}
else if (dayOrNight == "night")
{
    totalMoney = kilometers * 0.90 + 0.70;
}
Console.WriteLine($"{totalMoney:F2}");