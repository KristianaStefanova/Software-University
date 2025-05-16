double avalibleMoney = double.Parse(Console.ReadLine());
char gender = char.Parse(Console.ReadLine());
int age = int.Parse(Console.ReadLine());    
string sport = Console.ReadLine();

double finalPrice = 0.0;

if (gender == 'm')
{
    if (sport == "Gym")
    {
        finalPrice = 42;
    }
    else if (sport == "Boxing")
    {
        finalPrice = 41;
    }
    else if (sport == "Yoga")
    {
        finalPrice = 45;
    }
    else if (sport == "Zumba")
    {
        finalPrice = 34;
    }
    else if (sport == "Dances")
    {
        finalPrice = 51;
    }
    else if (sport == "Pilates")
    {
        finalPrice = 39;
    }
}
else if (gender == 'f')
{
    if (sport == "Gym")
    {
        finalPrice = 35;
    }
    else if (sport == "Boxing")
    {
        finalPrice = 37;
    }
    else if (sport == "Yoga")
    {
        finalPrice = 42;
    }
    else if (sport == "Zumba")
    {
        finalPrice = 31;
    }
    else if (sport == "Dances")
    {
        finalPrice = 53;
    }
    else if (sport == "Pilates")
    {
        finalPrice = 37;
    }
}

if (age <= 19)
{
    finalPrice *= 0.8;
}

if (avalibleMoney >= finalPrice)
{
Console.WriteLine($"You purchased a 1 month pass for {sport}.");

}
else
{
    double diff = finalPrice - avalibleMoney;
    Console.WriteLine($"You don't have enough money! You need ${diff:F2} more.");
}