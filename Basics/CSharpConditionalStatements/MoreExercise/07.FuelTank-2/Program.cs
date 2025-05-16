string fuel = Console.ReadLine();
double amountOfFuel = double.Parse(Console.ReadLine());
string clubCard = Console.ReadLine();

double finalPrice = 0.0;


if (fuel == "Gas")
{
    finalPrice = amountOfFuel * 0.93;
}
else if (fuel == "Gasoline")
{
    finalPrice = amountOfFuel * 2.22;
}
else if (fuel == "Diesel")
{
    finalPrice = amountOfFuel * 2.33;
}

if (clubCard == "Yes" && fuel == "Gas")
{
    finalPrice -= amountOfFuel * 0.08;
}
else if (clubCard == "Yes" && fuel == "Gasoline")
{
    finalPrice -= amountOfFuel * 0.18;
}
else if (clubCard == "Yes" && fuel == "Diesel")
{
    finalPrice -= amountOfFuel * 0.12;

}

if (amountOfFuel >= 20 && amountOfFuel <= 25)
{
    finalPrice *= 0.92;
}
else if (amountOfFuel > 25)
{
    finalPrice *= 0.90;
}
Console.WriteLine($"{finalPrice:F2} lv.");
