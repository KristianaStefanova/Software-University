int countKozunak = int.Parse(Console.ReadLine());

int sugerSum = 0;
int flourSum = 0;
int maxFlour = 0;
int maxSugar = 0;

for (int i = 0; i < countKozunak; i++)
{
    int sugar = int.Parse(Console.ReadLine());
    int flour = int.Parse(Console.ReadLine());

    sugerSum += sugar;
    flourSum += flour;

    if (sugar > maxSugar)
    {
        maxSugar = sugar;
    }
    if (flour > maxFlour)
    {
        maxFlour = flour;
    }
}
double countOfBoxesFlour = (double)flourSum / 750;
double countOfBoxesSugar = (double)sugerSum / 950;

Console.WriteLine($"Sugar: {Math.Ceiling(countOfBoxesSugar)}");
Console.WriteLine($"Flour: {Math.Ceiling(countOfBoxesFlour)}");
Console.WriteLine($"Max used flour is {maxFlour} grams, max used sugar is {maxSugar} grams.");

