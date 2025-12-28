
class Program
{
    static void Main()
    {
        double number = double.Parse(Console.ReadLine());
        int power = int.Parse(Console.ReadLine());
        
        double result = (CalculatePower(number, power));

        Console.WriteLine(result);
    }

    static double CalculatePower(double number, int pow)
    {
        double result = 1;

        for (int i = 1; i <= pow; i++)
        {
            result *= number;
        }

        return result;
    }
}

