int vineyard = int.Parse(Console.ReadLine());
double grapes1SqM = double.Parse(Console.ReadLine());
int expectedLitters = int.Parse(Console.ReadLine());
int countOfWorkers = int.Parse(Console.ReadLine());

double yardForWineProducing = vineyard * 0.4;

double totalKilogramsGrapes = grapes1SqM * yardForWineProducing;
double totalLittersWine = totalKilogramsGrapes / 2.5;   

if (totalLittersWine < expectedLitters)
{
    double neededLitters = expectedLitters - totalLittersWine;
    Console.WriteLine($"It will be a tough winter! More {Math.Floor(neededLitters)} liters wine needed.");
}
else
{
    double littersMore = totalLittersWine - expectedLitters;
    double wineForOneWorker = littersMore / countOfWorkers;

    Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(totalLittersWine)} liters.");
    Console.WriteLine($"{Math.Ceiling(littersMore)} liters left -> {Math.Ceiling(wineForOneWorker)} liters per person.");
}

  

