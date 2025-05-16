string name = Console.ReadLine();

int failedCounter = 0;
int gradesCounter = 1;
double sumAssessment = 0;

while (gradesCounter <= 12)
{
    double assessment = double.Parse(Console.ReadLine());

    if (assessment < 4)
    {
        failedCounter++;
        if (failedCounter == 2)
        {
            break;
        }
        continue;
    }

    gradesCounter++;
    sumAssessment += assessment;
}
if (gradesCounter >= 12)
{
    double averageAssessment = sumAssessment / 12;
    Console.WriteLine($"{name} graduated. Average grade: {averageAssessment:F2}");
}
else
{
    Console.WriteLine($"{name} has been excluded at {gradesCounter} grade");
}