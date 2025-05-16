string drink = Console.ReadLine();  
string suggar = Console.ReadLine();  
int countOfDrinks = int.Parse(Console.ReadLine());

double finalPrice = 0.0;
if (drink == "Espresso")
{
    if (suggar == "Without")
    {
        finalPrice = countOfDrinks * 0.90;
    }
    else if (suggar == "Normal")
    {
        finalPrice = countOfDrinks * 1.00;
    }
    else if (suggar == "Extra")
    {
        finalPrice = countOfDrinks * 1.20;
    }
}
else if (drink == "Cappuccino")
{
    if (suggar == "Without")
    {
        finalPrice = countOfDrinks * 1.00;
    }
    else if (suggar == "Normal")
    {
        finalPrice = countOfDrinks * 1.20;
    }
    else if (suggar == "Extra")
    {
        finalPrice = countOfDrinks * 1.60;
    }
}
else if (drink == "Tea")
{
    if (suggar == "Without")
    {
        finalPrice = countOfDrinks * 0.50;
    }
    else if (suggar == "Normal")
    {
        finalPrice = countOfDrinks * 0.60;
    }
    else if (suggar == "Extra")
    {
        finalPrice = countOfDrinks * 0.70;
    }
}

if (suggar == "Without")
{
    finalPrice *= 0.65;
}
if (drink == "Espresso" && countOfDrinks >= 5)
{
    finalPrice *= 0.75;
}
if (finalPrice > 15)
{
    finalPrice *= 0.80;
}

Console.WriteLine($"You bought {countOfDrinks} cups of {drink} for {finalPrice:F2} lv.");
