double priceStrawberry = double.Parse(Console.ReadLine());  
double kilogramsOfBananas = double.Parse(Console.ReadLine());
double kilogramsOfTangerine = double.Parse(Console.ReadLine());
double kilogramsOfRaspBery = double.Parse(Console.ReadLine());  
double kilogramsOfStrawberry = double.Parse(Console.ReadLine());

double priceRaspBerry = (priceStrawberry / 2) ;
double priceTangerine = (priceRaspBerry * 0.6) ;
double priceBanana = (priceRaspBerry * 0.2);

double totalPriceStrawberry = priceStrawberry * kilogramsOfStrawberry;
double totalPriceRaspBerry = priceRaspBerry * kilogramsOfRaspBery;
double totalpriceTangerine = priceTangerine * kilogramsOfTangerine;
double totalpriceBanana = priceBanana * kilogramsOfBananas;

double totalPrice = totalPriceStrawberry + totalPriceRaspBerry + totalpriceTangerine + totalpriceBanana;

Console.WriteLine($"{totalPrice:F2}");

