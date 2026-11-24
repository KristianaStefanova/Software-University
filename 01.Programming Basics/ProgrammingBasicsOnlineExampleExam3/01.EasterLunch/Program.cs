int countKozunak = int.Parse(Console.ReadLine());
int countEggsBoxes = int.Parse(Console.ReadLine());
int kilosKurabii = int.Parse(Console.ReadLine());

double paintPer1Egg = 0.15;

double priceKozunak = countKozunak * 3.20;
double priceEggs = countEggsBoxes * 4.35;
double priceKurabii = kilosKurabii * 5.40;
double finalPrice = priceEggs + priceKozunak + priceKurabii + (countEggsBoxes * 12 * paintPer1Egg);

Console.WriteLine($"{finalPrice:F2}");
