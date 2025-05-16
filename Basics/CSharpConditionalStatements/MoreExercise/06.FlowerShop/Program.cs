int countOfMagnolias = int.Parse(Console.ReadLine());
int countOfHyacinths  = int.Parse(Console.ReadLine());
int countOfRoses = int.Parse(Console.ReadLine());
int countOfCactuses  = int.Parse(Console.ReadLine());
double priceOfTheGift = double.Parse(Console.ReadLine());

double moneyFromFlowers = countOfMagnolias * 3.25 + countOfHyacinths * 4.00 + countOfRoses * 3.50 + countOfCactuses * 8.00;
double totalPrice = moneyFromFlowers * 0.95;

if (totalPrice >= priceOfTheGift)
{
    double moneyLeft = totalPrice - priceOfTheGift;
    Console.WriteLine($"She is left with {Math.Floor(moneyLeft)} leva.");
}
else
{
    double neededMoney = priceOfTheGift - totalPrice;
    Console.WriteLine($"She will have to borrow {Math.Ceiling(neededMoney)} leva.");
}