//Income 
double budget = double.Parse(Console.ReadLine());
int extras = int.Parse(Console.ReadLine());
double priceChlotes = double.Parse(Console.ReadLine());

//Calculation 
double decor = budget * 0.1;
double priceForExtra = priceChlotes * extras;

if (extras > 150)
{
    priceForExtra = priceForExtra - priceForExtra * 0.1;
}

double totalPrice = decor + priceForExtra;

if (totalPrice > budget)
{
    Console.WriteLine("Not enough money!");
    Console.WriteLine($"Wingard needs {totalPrice - budget:f2} leva more.");
}
else
{
    Console.WriteLine("Action!");
    Console.WriteLine($"Wingard starts filming with {budget - totalPrice:f2} leva left.");
}