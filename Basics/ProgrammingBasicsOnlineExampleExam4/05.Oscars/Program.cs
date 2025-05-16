string nameActor = Console.ReadLine();
double pointsAcademy = double.Parse(Console.ReadLine());
int countOfJury = int.Parse(Console.ReadLine());

double allPointsJury = 0;
double allPointsActor = pointsAcademy;

for (int i = 0; i < countOfJury; i++)
{
    string nameJury = Console.ReadLine();
    int length = nameJury.Length;
    double pointsJury = double.Parse(Console.ReadLine());
    allPointsJury = length * pointsJury / 2;
    allPointsActor += allPointsJury;


    if (allPointsActor >= 1250.5)
    {
        Console.WriteLine($"Congratulations, {nameActor} got a nominee for leading role with {allPointsActor:F1}!");

        break;
    }
}

if (allPointsActor < 1250.5)
{
    double neededPoints = 1250.5 - allPointsActor;
    Console.WriteLine($"Sorry, {nameActor} you need {neededPoints:F1} more!");
}
