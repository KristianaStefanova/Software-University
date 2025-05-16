int guests = int.Parse(Console.ReadLine());
double pricePerPerson = double.Parse(Console.ReadLine());
double budget = double.Parse(Console.ReadLine());

//Calculation
if (guests >= 10 && guests <= 15)
{

    pricePerPerson = pricePerPerson *= 0.85;
}
else if (guests > 15 && guests <= 20)
{
    pricePerPerson *= 0.80;
}
else if (guests > 20)
{
    pricePerPerson *= 0.75;
}
double priceCake = budget - (budget * 0.9);
double finalPriceBirthday = pricePerPerson * guests + priceCake;

if (budget >= finalPriceBirthday)
{
    double moneyLeft = budget - finalPriceBirthday;
    Console.WriteLine($"It is party time! {moneyLeft:F2} leva left.");
}
else
{
    double diff = Math.Abs(budget - finalPriceBirthday);
    Console.WriteLine($"No party! {diff:F2} leva needed.");
}