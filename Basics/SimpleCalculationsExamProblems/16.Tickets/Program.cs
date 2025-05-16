double budget = double.Parse(Console.ReadLine());
string category =Console.ReadLine();
int countOfPeople = int.Parse(Console.ReadLine());

double finalPrice = 0.0;
double priceForTickets = 0.0;
double transport = 0.0;

if (countOfPeople >= 50)
{
    transport = budget * 0.25;
}
else if (countOfPeople >= 25 && countOfPeople <= 49)
{
    transport = budget * 0.40;
}
else if (countOfPeople >= 10 && countOfPeople <= 24)
{
    transport = budget * 0.50;
}
else if (countOfPeople >= 5 && countOfPeople <= 9)
{
    transport = budget * 0.60;
}
else
{
    transport = budget * 0.75;
}

if (category == "VIP")
{
    priceForTickets = countOfPeople * 499.99;
}
else if (category == "Normal")
{
    priceForTickets = countOfPeople * 249.99;
}

finalPrice = priceForTickets + transport;

if (finalPrice <= budget)
{
    double moneyLeft = budget - finalPrice;
    Console.WriteLine($"Yes! You have {moneyLeft:F2} leva left.");
}
else 
{
    double neededMoney = finalPrice - budget;
    Console.WriteLine($"Not enough money! You need {neededMoney:F2} leva.");
}
