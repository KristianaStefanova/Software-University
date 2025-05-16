int countOfPeopleJury = int.Parse(Console.ReadLine());
string namePresentation = Console.ReadLine();
double sumAllGrades = 0;
double averageSumAllGrades = 0;
int counter = 0;

while (namePresentation != "Finish")
{
    double sumGradesPerPresentation = 0;


    for (int i = 0; i < countOfPeopleJury; i++)
    {
        double grade = double.Parse(Console.ReadLine());
        counter++;
        sumGradesPerPresentation += grade;
        sumAllGrades += grade;
    }
    double averageSumPerPresentation = sumGradesPerPresentation / countOfPeopleJury;
    Console.WriteLine($"{namePresentation} - {averageSumPerPresentation:F2}.");

    namePresentation = Console.ReadLine();
}
if (namePresentation == "Finish")
{
    averageSumAllGrades = sumAllGrades / counter;
    Console.WriteLine($"Student's final assessment is {averageSumAllGrades:F2}.");
}