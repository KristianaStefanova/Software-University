int minutesOfWalk = int.Parse(Console.ReadLine());
int couontOfWalksPerDay = int.Parse(Console.ReadLine());    
int eatenCaloriesPerDay = int.Parse(Console.ReadLine());

int totalCaloriesPerDay = minutesOfWalk * couontOfWalksPerDay * 5;
int permitedCalories = eatenCaloriesPerDay / 2;

if (permitedCalories <= totalCaloriesPerDay)
{
    Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {totalCaloriesPerDay}.");
}
else
{
    Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {totalCaloriesPerDay}.");
}