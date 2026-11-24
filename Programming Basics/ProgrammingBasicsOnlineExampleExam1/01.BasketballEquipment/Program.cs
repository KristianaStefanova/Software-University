int feePerYear = int.Parse(Console.ReadLine());

double priceBasketballShoes = feePerYear - feePerYear * 0.4;
double priceEquipment = priceBasketballShoes - priceBasketballShoes * 0.2;
double priceBall = priceEquipment / 4;
double priceAccessories = priceBall / 5;

double finalPrice = feePerYear + priceBasketballShoes + priceEquipment + priceBall + priceAccessories;

Console.WriteLine($"{finalPrice:F2}");
