string month = Console.ReadLine();
int countOfDays = int.Parse(Console.ReadLine());

double priceStudio = 0.0;
double priceApartment = 0.0;

if (month == "May" || month == "October")
{
    priceStudio = countOfDays * 50;
    priceApartment = countOfDays * 65;

    if (countOfDays > 14)
    {
        priceStudio *= 0.7;
        priceApartment *= 0.9;
    }
    else if (countOfDays > 7)
    {
        priceStudio *= 0.95;
    }
}
else if (month == "June" || month == "September")
{
    priceStudio = countOfDays * 75.20;
    priceApartment = countOfDays * 68.70;

    if (countOfDays > 14)
    {
        priceStudio *= 0.8;
        priceApartment *= 0.9;
    }
}
else if (month == "July" || month == "August")
{
    priceStudio = countOfDays * 76;
    priceApartment = countOfDays * 77;

    if (countOfDays > 14)
    {
        priceApartment *= 0.9;
    }
}

Console.WriteLine($"Apartment: {priceApartment:F2} lv");
Console.WriteLine($"Studio: {priceStudio:F2} lv");
