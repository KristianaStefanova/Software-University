int days = int.Parse(Console.ReadLine());
double food = double.Parse(Console.ReadLine());

int totalEatenFoodByDog = 0;
int totalEatenFoodByCat = 0;
double biscuits = 0;

for (int i = 1; i <= days; i++)
{
    int eatenFoodByDog = int.Parse(Console.ReadLine());
    int eatenFoodByCat = int.Parse(Console.ReadLine());

    totalEatenFoodByDog += eatenFoodByDog;
    totalEatenFoodByCat += eatenFoodByCat;

    if (i % 3 == 0)
    {
        biscuits += 0.1 * (eatenFoodByCat + eatenFoodByDog);
    }
}
double totalEatenFood = totalEatenFoodByCat + totalEatenFoodByDog;

Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuits)}gr.");

double percentTotalEatenFood = totalEatenFood / food * 100;
Console.WriteLine($"{percentTotalEatenFood:F2}% of the food has been eaten.");

double percentEatenFoodByDog = totalEatenFoodByDog / totalEatenFood * 100;
Console.WriteLine($"{percentEatenFoodByDog:F2}% eaten from the dog.");

double percentEatenFoodByCat = totalEatenFoodByCat / totalEatenFood * 100;
Console.WriteLine($"{percentEatenFoodByCat:F2}% eaten from the cat.");

