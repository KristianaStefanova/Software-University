string nameActor = Console.ReadLine();
double pointsAcademy = double.Parse(Console.ReadLine());
int numberOfАudience = int.Parse(Console.ReadLine());


for (int i = 0; i < numberOfАudience; i++)
{
    string nameAudience = Console.ReadLine();
    double score = double.Parse(Console.ReadLine());

    double currentPoints = nameAudience.Length * score / 2;
    pointsAcademy += currentPoints;

    if (pointsAcademy >= 1250.5)
    {
        Console.WriteLine($"Congratulations, {nameActor} got a nominee for leading role with {pointsAcademy:F1}!");
        break;
    }

}
if (pointsAcademy < 1250.5)

{
    double neededPoints = 1250.5 - pointsAcademy;
    Console.WriteLine($"Sorry, {nameActor} you need {neededPoints:F1} more!");
}
