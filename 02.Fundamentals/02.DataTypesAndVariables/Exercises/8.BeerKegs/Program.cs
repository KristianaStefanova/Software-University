using System.Globalization;

class Program
{
    static void Main()
    {
        int counter = int.Parse(Console.ReadLine());
        string modelBiggestKeg = "";
        double biguestKeg = 0;

        for (int i = 0; i < counter; i++) 
        {
            string model = Console.ReadLine();
            double radiud = double.Parse(Console.ReadLine()); 
            double height = double.Parse(Console.ReadLine());

            double result = Math.PI * Math.Pow(radiud, 2) * height;
            if (biguestKeg < result)
            {
                biguestKeg = result;
                modelBiggestKeg = model;

            }
        }

        Console.WriteLine(modelBiggestKeg);
    }
}

