string month = Console.ReadLine();
int countDays = int.Parse(Console.ReadLine());

double studioPrice;
double apartmentPrice;

switch (month)
{
    case "May":
    case "October":
        studioPrice = 50;
        apartmentPrice = 65;
        break;
    case "June":
    case "September":
        studioPrice = 75.20;
        apartmentPrice = 68.70;
        break;
    case "July":
    case "August":
    default:
        studioPrice = 76;
        apartmentPrice = 77;
        break;
}
double studioCost = countDays * studioPrice;
double apartmentCost = countDays * apartmentPrice;

if (countDays > 7 && countDays < 14)
{
    if (month == "May" || month == "October")
    {
        studioCost *= 0.95;
    }
}
else if (countDays > 14)
{
    if (month == "May" || month == "October")
    {
        studioCost *= 0.7;
    }
    else if (month == "June" || month == "September")
    {
        studioCost *= 0.80;
    }
    apartmentCost *= 0.9;
}
Console.WriteLine($"Apartment: {apartmentCost:f2} lv.");
Console.WriteLine($"Studio: {studioCost:f2} lv.");