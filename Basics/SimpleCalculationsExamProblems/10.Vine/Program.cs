using System.Security.Cryptography;

int wineYardArea = int.Parse(Console.ReadLine());
double grapePerSquare = double.Parse(Console.ReadLine());
int neededLitters = int.Parse(Console.ReadLine());
int workers = int.Parse(Console.ReadLine());

double harvestArea = wineYardArea * 0.4;
double vineKilograms = harvestArea * grapePerSquare;
double allLittersVine = vineKilograms / 2.5;

if (allLittersVine > neededLitters)
{
    Console.WriteLine($"Good harvest this year! Total wine: {Math.Round(allLittersVine)} liters.");
    double littersLeft = allLittersVine - neededLitters;
    double LittersPerWorker = littersLeft / workers;
    Console.WriteLine($"{littersLeft} liters left -> {Math.Ceiling(LittersPerWorker)} liters per person.");
}
else
{
    double diff = neededLitters - allLittersVine; 
    Console.WriteLine($"It will be a tough winter! More {Math.Floor(diff)} liters wine needed.");
}