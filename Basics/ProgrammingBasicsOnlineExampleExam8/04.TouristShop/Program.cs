double budget = double.Parse(Console.ReadLine());

int counter = 0;
int counterPromotion = 0;
double totalPrice = 0.0;

while (true)
{
    string input = Console.ReadLine();

    if (input == "Stop")
    {
        break;
    }

    string nameProduct = input;

    double priceProduct = double.Parse(Console.ReadLine());

    counter++;
    counterPromotion++;

    if (counterPromotion > 2)
    {
        counterPromotion = 0;
        priceProduct /= 2;
    }

    totalPrice += priceProduct;

    if (totalPrice > budget)
    {
        break;
    }
}

if (totalPrice > budget)
{
    double neededMoney = totalPrice - budget;
    Console.WriteLine($"You don't have enough money!");
    Console.WriteLine($"You need {neededMoney:F2} leva!");
}
else
{
    Console.WriteLine($"You bought {counter} products for {totalPrice:F2} leva.");
}