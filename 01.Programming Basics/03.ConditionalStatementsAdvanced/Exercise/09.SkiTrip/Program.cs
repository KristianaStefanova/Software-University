int countOfDays = int.Parse(Console.ReadLine());
string typeOfRoom = Console.ReadLine();
string typeOfReview = Console.ReadLine();

double totalSum;
int nightsHotel = countOfDays - 1;

switch (typeOfRoom) 
{
    case "room for one person":
        totalSum = nightsHotel * 18;
        break;
    case "apartment":
        totalSum = nightsHotel * 25;
        break;
    case "president apartment":
    default:
       totalSum = nightsHotel * 35;
    break;
}

if (nightsHotel < 10)
{
    
    if (typeOfRoom == "apartment")
    {
        totalSum *= 0.7; 
    }
    else if (typeOfRoom == "president apartment")
    {
        totalSum *= 0.9;
    }
    
}
else if (nightsHotel >= 10 && nightsHotel <= 15)
{
    if (typeOfRoom == "apartment")
    {
        totalSum *= 0.65;
    }
    else if (typeOfRoom == "president apartment")
    {
        totalSum *= 0.85;
    }
}
else
{
    if (typeOfRoom == "apartment")
    {
        totalSum *= 0.50;
    }
    else if (typeOfRoom == "president apartment")
    {
        totalSum *= 0.80;
    }
}

if (typeOfReview == "positive")
{
    totalSum *= 1.25;
    
}
else if (typeOfReview == "negative")
{
    totalSum *= 0.9;
    
}
Console.WriteLine($"{totalSum:F2}");
