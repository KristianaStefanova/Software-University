//Prices
double pricePens = 5.80; 
double priceMarkers = 7.20; 
double pricePreparat = 1.20;



int countOfPens = int.Parse(Console.ReadLine());
int countOfMarkers = int.Parse(Console.ReadLine());
int litersPreparat = int.Parse(Console.ReadLine());
int percentDiscount = int.Parse(Console.ReadLine());

double priceForAllPens = countOfPens * pricePens;
double priceForAllMarkers = countOfMarkers * priceMarkers;
double priceForAllPreparat = litersPreparat * pricePreparat;

double priceForAllProducts = priceForAllPens + priceForAllMarkers + priceForAllPreparat;
double discount = priceForAllProducts * percentDiscount / 100;
double finalPrice = priceForAllProducts - discount;

Console.WriteLine(finalPrice);





