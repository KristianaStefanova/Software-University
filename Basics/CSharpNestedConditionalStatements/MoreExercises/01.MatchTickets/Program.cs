double budget = double.Parse(Console.ReadLine());
string category  = Console.ReadLine();
int countOfPeople = int.Parse(Console.ReadLine());

double money = 0.0;
double ticketVip = 499.99;
double ticketNormal = 249.99;


if (countOfPeople >= 1 && countOfPeople <= 4)
{
    money += budget * 0.75;
    if (category == "VIP")
    {
        money += countOfPeople * ticketVip;
    }
    else if (category == "Normal")
    {
        money += countOfPeople * ticketNormal;
    }
}
else if (countOfPeople >= 5 && countOfPeople <= 9)
{
    money += budget * 0.60;
    if (category == "VIP")
    {
        money += countOfPeople * ticketVip;
    }
    else if (category == "Normal")
    {
        money += countOfPeople * ticketNormal;
    }
}
else if (countOfPeople >= 10 && countOfPeople <= 24)
{
    money += budget * 0.50;
    if (category == "VIP")
    {
        money += countOfPeople * ticketVip;
    }
    else if (category == "Normal")
    {
        money += countOfPeople * ticketNormal;
    }
}
else if (countOfPeople >= 25 && countOfPeople <= 49)
{
    money += budget * 0.40;
    if (category == "VIP")
    {
        money += countOfPeople * ticketVip;
    }
    else if (category == "Normal")
    {
        money += countOfPeople * ticketNormal;
    }
}
else if (countOfPeople >= 50)
{
    money += budget * 0.25;
    if (category == "VIP")
    {
        money += countOfPeople * ticketVip;
    }
    else if (category == "Normal")
    {
        money += countOfPeople * ticketNormal;
    }
}

if (budget >= money)
{
    double moneyLeft = budget - money;
    Console.WriteLine($"Yes! You have {moneyLeft:F2} leva left.");
}
else
{
    double neededMoney = money - budget;
    Console.WriteLine($"Not enough money! You need {neededMoney:F2} leva.");
}