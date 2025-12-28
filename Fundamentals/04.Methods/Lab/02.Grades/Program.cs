
class Program
{
    static void Main()
    {
        double grade = double.Parse(Console.ReadLine());

        PrintGradeDefinition(grade);
    }

    private static void PrintGradeDefinition(double grade)
    {
        if (grade is >= 2.00 and < 3.00)
        {
            Console.WriteLine("Fail"); 
        }
        else if (grade is >= 3.00 and < 3.50)
        {
            Console.WriteLine("Poor");
        }
        else if (grade is >= 3.50 and < 4.50)
        {
            Console.WriteLine("Good");
        }
        else if (grade is >= 4.50 and < 5.50)
        {
            Console.WriteLine("Very good");
        }
        else if (grade is >= 5.50 )
        {
            Console.WriteLine("Excellent");
        }
    }
}

