int food = int.Parse(Console.ReadLine());
string input = Console.ReadLine();
int totalEatenFood = 0;

while (input != "Adopted")
{
    int countOfFood = int.Parse(input);

    totalEatenFood += countOfFood;

    input = Console.ReadLine();
}
int foodInGrams = food * 1000;

if (foodInGrams >= totalEatenFood)
{
    int foodLeft = foodInGrams - totalEatenFood;
    Console.WriteLine($"Food is enough! Leftovers: {foodLeft} grams.");
}
else
{
    int neededFood = totalEatenFood - foodInGrams;
    Console.WriteLine($"Food is not enough. You need {neededFood} grams more.");
}
