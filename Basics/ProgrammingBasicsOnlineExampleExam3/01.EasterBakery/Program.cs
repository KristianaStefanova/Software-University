double flourPrice1K = double.Parse(Console.ReadLine());   
double countKilogramsFlour = double.Parse(Console.ReadLine());   
double kilogramsSugar  = double.Parse(Console.ReadLine());
int eggsBoxes = int.Parse(Console.ReadLine());
int countYeast = int.Parse(Console.ReadLine());

double price1KSugar = flourPrice1K - (flourPrice1K * 0.25);
double pricePerEggsBox = flourPrice1K * 1.1;
double pricePerOneYeast = price1KSugar - (price1KSugar * 0.8);

double finalPrice = flourPrice1K * countKilogramsFlour + (kilogramsSugar * price1KSugar) + (eggsBoxes * pricePerEggsBox) + (countYeast * pricePerOneYeast);

Console.WriteLine($"{finalPrice:F2}");