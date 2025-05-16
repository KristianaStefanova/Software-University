string month = Console.ReadLine();
int countDays = int.Parse(Console.ReadLine());

double finalPriceApartment;
double finalPriceStudio;


if (month == "May" || month == "October")
{
    finalPriceStudio = countDays * 50;
    finalPriceApartment = countDays * 65;
    if (countDays > 14)
    {
        finalPriceStudio *= 0.70;
    }
    else if (countDays > 7)
    {
        finalPriceStudio *= 0.95;
    }
}
if (countDays > 14)
{
    finalPriceApartment *= 0.90;
}


else if (month == "June" || month == "September")
{
    finalPriceStudio = countDays * 75.20;
    finalPriceApartment = countDays * 68.70;
    if (countDays > 14)
    {
        finalPriceStudio *= 0.80;
    }

    if (countDays > 14)
    {
        finalPriceApartment *= 0.90;
    }
}

else if (month == "July" || month == "August")
{
    finalPriceStudio = countDays * 76;
    finalPriceApartment = countDays * 77;
    if (countDays > 14)
    {
        finalPriceApartment *= 0.90;
    }
    else
    {
        finalPriceStudio = countDays * 76;
        finalPriceApartment = countDays * 77;
    }
}



Console.WriteLine($"Apartment: {finalPriceApartment:f2} lv.");
Console.WriteLine($"Studio: {finalPriceStudio:f2} lv.");
