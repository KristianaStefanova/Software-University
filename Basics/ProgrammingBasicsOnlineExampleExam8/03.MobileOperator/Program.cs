string term = Console.ReadLine();
string typeOfContract  = Console.ReadLine();
string extraInternet = Console.ReadLine();
int countOfMonths = int.Parse(Console.ReadLine());

double finalPrice = 0;

if (term == "one")
{
    if (typeOfContract == "Small")
    {
        finalPrice = 9.98;
    }
    else if (typeOfContract == "Middle")
    {
        finalPrice = 18.99;
    }
    else if (typeOfContract == "Large")
    {
        finalPrice = 25.98;
    }
    else if (typeOfContract == "ExtraLarge")
    {
        finalPrice = 35.99;
    }  
}
else if (term == "two")
{
    if (typeOfContract == "Small")
    {
        finalPrice = 8.58;
    }
    else if (typeOfContract == "Middle")
    {
        finalPrice = 17.09;
    }
    else if (typeOfContract == "Large")
    {
        finalPrice = 23.59;
    }
    else if (typeOfContract == "ExtraLarge")
    {
        finalPrice = 31.79;
    }
}

if (extraInternet == "yes")
{
    if (finalPrice <= 10)
    {
        finalPrice += 5.50;
    }
    else if (finalPrice <= 30)
    {
        finalPrice += 4.35;
    }
    else if (finalPrice > 30)
    {
        finalPrice += 3.85;
    }
}

finalPrice *= countOfMonths;

if (term == "two")
{
    finalPrice *= 0.9625;
}

Console.WriteLine($"{finalPrice:F2} lv.");