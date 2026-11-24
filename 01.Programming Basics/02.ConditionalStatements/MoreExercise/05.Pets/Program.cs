int countOfDays =int.Parse(Console.ReadLine());
int leftedFood =int.Parse(Console.ReadLine());
double dogsFood =double.Parse(Console.ReadLine());
double catsFood =double.Parse(Console.ReadLine());
double turtleFoodIngrams =double.Parse(Console.ReadLine());

double turtlesFoodInKilograms = turtleFoodIngrams / 1000;

double totalFood = (dogsFood + catsFood + turtlesFoodInKilograms) * countOfDays;

if (leftedFood >= totalFood)
{
    double foodLeft = leftedFood - totalFood;
    Console.WriteLine($"{Math.Floor(foodLeft)} kilos of food left.");
}
else
{
    double neededFood = totalFood - leftedFood;
    Console.WriteLine($"{Math.Ceiling(neededFood)} more kilos of food are needed.");
}