using System.Globalization;

class Program
{
    static void Main()
    {
        string type = Console.ReadLine();

        if (type == "int")
        {
            int number = int.Parse(Console.ReadLine());
            ConvertInput(number);
        }
        else if (type == "real")
        {
            double number = double.Parse(Console.ReadLine());
            ConvertInput(number);
        }
        else if (type == "string")
        {
            string input = Console.ReadLine();
            ConvertInput(input);
        }
    }
    static void ConvertInput(int number)
    {
        number *= 2;
        Console.WriteLine(number);
    }

    static void ConvertInput(double number)
    {
        number *= 1.5;
        Console.WriteLine($"{number:F2}");
    }

    static void ConvertInput(string input)
    {
        input = $"${input}$";
        Console.WriteLine(input);
    }

}

