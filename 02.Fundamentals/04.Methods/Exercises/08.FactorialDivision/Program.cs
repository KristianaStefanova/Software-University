

class Program
{
    static void Main()
    {
        int firstNum = int.Parse(Console.ReadLine());   
        int secondNum = int.Parse(Console.ReadLine());

        double facorialFirstNum = CalculateFactoril(firstNum);
        double facorialSecondNum = CalculateFactoril(secondNum);
        double result = Divide(facorialFirstNum, facorialSecondNum);

        Console.WriteLine($"{result:F2}");
    }

    static double Divide(double facorialFirstNum, double facorialSecondNum)
    {
        double result = (double)facorialFirstNum / facorialSecondNum;

        return result;
    }

    static double CalculateFactoril(int number)
    {
        double result = number;

        for (long i = number - 1; i >= 1; i--)
        {
            result *= i;
        }

        return result;
    }
}

