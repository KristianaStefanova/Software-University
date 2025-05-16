//Input
int practiceForOneYear = int.Parse(Console.ReadLine());

//Calculation 
double priceForShoes = practiceForOneYear - practiceForOneYear * 0.40;
double priceEquipment =  priceForShoes - priceForShoes * 0.20;
double priceBall = priceEquipment / 4;
double priceAccessories = priceBall / 5;

double priceForAllEquipment = practiceForOneYear + priceForShoes + priceEquipment + priceBall + priceAccessories;

//Output
Console.WriteLine(priceForAllEquipment);