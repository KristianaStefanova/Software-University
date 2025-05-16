double budget = double.Parse(Console.ReadLine());
int countOfDays = int.Parse(Console.ReadLine());
double pricePerNight = double.Parse(Console.ReadLine());
int percentExtraExpence = int.Parse(Console.ReadLine());

double moneyForTrip = 0.0;

if (countOfDays > 7)
{
    pricePerNight *= 0.95;
    moneyForTrip += pricePerNight * countOfDays;
}
else
{
    moneyForTrip += pricePerNight * countOfDays;
}

double extraMoney = budget * percentExtraExpence / 100;
moneyForTrip += extraMoney;

if (moneyForTrip <= budget)
{
    double diff = budget - moneyForTrip;
    Console.WriteLine($"Ivanovi will be left with {diff:F2} leva after vacation.");
}
else
{
    double neededMoney = moneyForTrip - budget;
    Console.WriteLine($"{neededMoney:F2} leva needed.");
}
