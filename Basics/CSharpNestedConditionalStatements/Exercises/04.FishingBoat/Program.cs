int budget = int.Parse(Console.ReadLine());
string season = Console.ReadLine();
int countFisherman = int.Parse(Console.ReadLine());

double priceOfBoat = 0;

switch (season)
{
    case "Spring":
        priceOfBoat = 3000;
        break;
    case "Winter":
        priceOfBoat = 2600;
        break;
    case "Summer":
    case "Autumn":
    default:
        priceOfBoat = 4200;
        break;
}

if (countFisherman <= 6)
{
    priceOfBoat *= 0.9;
}
else if (countFisherman <= 11)
{
    priceOfBoat *= 0.85;
}
else
{
    priceOfBoat *= 0.75;
}
if (countFisherman % 2 == 0 && season != "Autumn")
{
    priceOfBoat *= 0.95;
}

if (priceOfBoat <= budget)
{
    Console.WriteLine($"Yes! You have {budget - priceOfBoat:F2} leva left.");
}
else
{
    Console.WriteLine($"Not enough money! You need {priceOfBoat - budget:F2} leva.");
}