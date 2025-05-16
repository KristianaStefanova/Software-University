double budget = double.Parse(Console.ReadLine());
int countOfStatists = int.Parse(Console.ReadLine());
double priceClothesOneStatist = double.Parse(Console.ReadLine());

double decor = budget * 0.1;

if (countOfStatists > 150)
{
    priceClothesOneStatist *= 0.9;
}
double finalPrice = decor + (countOfStatists * priceClothesOneStatist);

if (finalPrice <= budget)
{
    double moneyLeft = budget - finalPrice;
    Console.WriteLine("Action!");
    Console.WriteLine($"Wingard starts filming with {moneyLeft:F2} leva left.");
}
else
{
    double diff = Math.Abs(finalPrice - budget);
    Console.WriteLine($"Not enough money!");
    Console.WriteLine($"Wingard needs {diff:F2} leva more.");
}