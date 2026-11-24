//Prices
double priceForNylon = 1.50;
double priceForPaint = 14.50;
double priceForDistiller = 5;
double priceForBag = 0.40;



// Input
int nylon = int.Parse(Console.ReadLine());
int paint = int.Parse(Console.ReadLine());
int distiller = int.Parse(Console.ReadLine());
int hoursForWorkers = int.Parse(Console.ReadLine());

 
// Calculatins
double finalPriceForPaint = (paint + (paint * 0.1)) * priceForPaint;
double finalPriceForNylon = (nylon + 2) * priceForNylon;
double finalPriceForDistiller = distiller * priceForDistiller;
double finalPriceAllProducts = finalPriceForNylon + finalPriceForPaint + finalPriceForDistiller + priceForBag;

double priceOfOneHourWorkers = finalPriceAllProducts * 0.30;

double finalPrice = finalPriceAllProducts + (hoursForWorkers * priceOfOneHourWorkers);

//Output
Console.WriteLine(finalPrice);










