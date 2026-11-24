int countOfStudents = int.Parse(Console.ReadLine());

double topStudents = 0.0;
double between4And499 = 0.0;
double between3And399 = 0.0;
double fail = 0.0;
double average = 0.0;
double sumAll = 0.0;

int countTop = 0;
int countBetween4And499 = 0;
int countBetween3And399 = 0;
int countFail = 0;

for (int i = 0; i < countOfStudents; i++)
{
    double grade = double.Parse(Console.ReadLine());

    if (grade >= 5.00)
    {
        countTop++;
    }
    else if (grade >= 4.00 && grade <= 4.99)
    {
        countBetween4And499++;
    }
    else if (grade >= 3.00 && grade <= 3.99)
    {
        countBetween3And399++;
    }
    else
    {
        countFail++;
    }
    sumAll += grade;
}

topStudents = (double)countTop / countOfStudents * 100;
between4And499 = (double)countBetween4And499 / countOfStudents * 100;
between3And399 = (double)countBetween3And399 / countOfStudents * 100;
fail = (double)countFail / countOfStudents * 100;
average = sumAll / countOfStudents;

Console.WriteLine($"Top students: {topStudents:F2}%");
Console.WriteLine($"Between 4.00 and 4.99: {between4And499:F2}%");
Console.WriteLine($"Between 3.00 and 3.99: {between3And399:F2}%");
Console.WriteLine($"Fail: {fail:F2}%");
Console.WriteLine($"Average: {average:F2}");