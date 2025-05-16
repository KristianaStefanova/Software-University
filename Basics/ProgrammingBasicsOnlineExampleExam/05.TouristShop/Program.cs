double budget = double.Parse(Console.ReadLine());

string input = Console.ReadLine();

double priceAllProducts = 0.0;
int counterPromotion = 0;
int counter = 0;


while (input != "Stop")
{
    string nameProduct = input;

    double priceProduct = double.Parse(Console.ReadLine());

    counter++;
    counterPromotion++;

    if (counterPromotion > 2)
    {
        priceProduct /= 2;
        counterPromotion = 0;
    }

    priceAllProducts += priceProduct;

    if (priceAllProducts > budget)
    {
        break;
    }
   
    input = Console.ReadLine();
}

if (budget < priceAllProducts) 
{
    double neededMoney = priceAllProducts - budget;

    Console.WriteLine("You don't have enough money!");
    Console.WriteLine($"You need {neededMoney:F2} leva!");
}
else 
{
    Console.WriteLine($"You bought {counter} products for {priceAllProducts:F2} leva.");
}