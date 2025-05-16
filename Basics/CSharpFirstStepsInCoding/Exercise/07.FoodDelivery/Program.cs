//Prices	

double priceChickenMenu = 10.35; 
double priceFishMenu = 12.40; 
double priceVegetarianMenu = 8.15;
double priceForDelivery = 2.50;

//Input
int countChickenMenu = int.Parse(Console.ReadLine());
int countFishMenu = int.Parse(Console.ReadLine());
int countVegetarianMenu = int.Parse(Console.ReadLine());

//Calculation
double priceForAllChickenMenus = countChickenMenu * priceChickenMenu;
double priceForAllFishMenus = countFishMenu * priceFishMenu;
double priceForAllVegetarianMenus = countVegetarianMenu * priceVegetarianMenu;

double priceForAllMenus = priceForAllChickenMenus + priceForAllFishMenus + priceForAllVegetarianMenus;
double PriceForDeserts = priceForAllMenus * 0.20;
double finalPriceForOrder = priceForAllMenus + PriceForDeserts + priceForDelivery;

//Output
Console.WriteLine(finalPriceForOrder);





