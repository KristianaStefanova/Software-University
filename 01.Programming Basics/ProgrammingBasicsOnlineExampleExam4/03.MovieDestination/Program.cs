double budget = double.Parse(Console.ReadLine());
string destination = Console.ReadLine();
string season = Console.ReadLine();
int countOfDays = int.Parse(Console.ReadLine());

double finalPrice = 0;

if (destination == "Dubai")
{
    switch (season)
    {
        case "Winter":
            finalPrice = 45000 * countOfDays;

            break;
        case "Summer":
            finalPrice = 40000 * countOfDays;
            break;
    }
}
else if (destination == "Sofia")
{
    switch (season)
    {
        case "Winter":
            finalPrice = 17000 * countOfDays;
            break;
        case "Summer":
            finalPrice = 12500 * countOfDays;
            break;
    }
}
else if (destination == "London")
{
    switch (season)
    {
        case "Winter":
            finalPrice = 24000 * countOfDays;
            break;
        case "Summer":
            finalPrice = 20250 * countOfDays;
            break;
    }
}

if (destination == "Dubai")
{
    finalPrice *= 0.7;
}
else if (destination == "Sofia")
{
    finalPrice *= 1.25;
}

if (budget >= finalPrice)
{
    double moneyLeft = budget - finalPrice;
    Console.WriteLine($"The budget for the movie is enough! We have {moneyLeft:F2} leva left!");

}
else if (budget < finalPrice)
{
    double diff = Math.Abs(finalPrice - budget);
    Console.WriteLine($"The director needs {diff:F2} leva more!");
}