
class Program
{
    static void Main()
    {
        double weigth = int.Parse(Console.ReadLine());
        double height = int.Parse(Console.ReadLine());
        double area = GetRectagleArea(weigth, height);
        Console.WriteLine(area);
    }
    static double GetRectagleArea(double a, double b)
    {
        double result = a * b;
        return result;
    }
}

