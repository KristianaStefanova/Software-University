double priceVegetablesOneK = double.Parse(Console.ReadLine());
double priceFrutessOneK = double.Parse(Console.ReadLine());
int kilogramsOfVegetables = int.Parse(Console.ReadLine());
int kilogramsOfFrutes = int.Parse(Console.ReadLine());

double finalPriceVegetables = priceVegetablesOneK * kilogramsOfVegetables / 1.94;
double finalPriceFrutes = priceFrutessOneK * kilogramsOfFrutes / 1.94;

double finalPrice = finalPriceVegetables + finalPriceFrutes;

Console.WriteLine(finalPrice);