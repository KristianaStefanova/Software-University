class Program
{
    static void Main()
    {
        double x1 = double.Parse(Console.ReadLine());
        double y1 = double.Parse(Console.ReadLine());
        double x2 = double.Parse(Console.ReadLine());
        double y2 = double.Parse(Console.ReadLine());

        CenterCloserPoint(x1, y1, x2, y2);
    }

    static void CenterCloserPoint(double x1, double y1, double x2, double y2)
    {
        double firstPointDistance = Math.Sqrt((x1 * x1) + (y1 * y1));
        double secindPointDistance = Math.Sqrt((x2 * x2) + (y2 * y2));

        if (firstPointDistance > secindPointDistance)
        {
            Console.WriteLine($"({x2}, {y2})");
        }
        else
        {
            Console.WriteLine($"({x1}, {y1})");
        }
    }
}
