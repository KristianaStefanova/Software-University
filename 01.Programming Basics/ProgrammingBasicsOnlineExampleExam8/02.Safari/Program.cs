double budget = double.Parse(Console.ReadLine());
double gasoline = double.Parse(Console.ReadLine());
string day = Console.ReadLine();

double finalSum = 0;
double priceGasoline = gasoline * 2.10;
finalSum = priceGasoline + 100;

if (day == "Saturday")
{
    finalSum *= 0.90;
}
else if (day == "Sunday")
{
    finalSum *= 0.80;
}

if (finalSum <= budget)
{
    double diff = budget - finalSum;
    Console.WriteLine($"Safari time! Money left: {diff:F2} lv.");
}
else
{
    double neededMoney = finalSum - budget;
    Console.WriteLine($"Not enough money! Money needed: {neededMoney:F2} lv.");
}