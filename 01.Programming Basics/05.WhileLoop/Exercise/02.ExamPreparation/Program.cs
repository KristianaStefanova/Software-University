int numberFaliedAssessment = int.Parse(Console.ReadLine());

int faliedCounter = 0;
int numOfProblems = 0;
int gradeSum = 0;
string lastProblem = "";

while (true)
{
    string name = Console.ReadLine();
    if (name == "Enough")
    {
        double avarageGrade = (double)gradeSum / numOfProblems;
        Console.WriteLine($"Average score: {avarageGrade:F2}");
        Console.WriteLine($"Number of problems: {numOfProblems}");
        Console.WriteLine($"Last problem: {lastProblem}");
        break;
    }
    int assessment = int.Parse(Console.ReadLine());

    numOfProblems++;
    gradeSum += assessment;

    if (assessment <= 4)
    {
        faliedCounter++;
       
        if (faliedCounter == numberFaliedAssessment)
        {
            Console.WriteLine($"You need a break, {faliedCounter} poor grades.");
            break;
        }
    }

    lastProblem = name;
}
