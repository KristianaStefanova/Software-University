using System.Dynamic;

class Program
{
    static void Main()
    {

        string input = Console.ReadLine();

        while (input != "END")
        {
            if (int.TryParse(input, out int number))
            {
                Console.WriteLine($"{input} is integer type");
            }
            else if (float.TryParse(input, out float point))
            {
                Console.WriteLine($"{input} is floating point type");
            }
            else if (char.TryParse(input, out char character))
            {
                Console.WriteLine($"{input} is character type");
            }
            else if (bool.TryParse(input, out bool value))
            {
                Console.WriteLine($"{input} is boolean type");
            }
            else
            {
                Console.WriteLine($"{input} is string type");
            }

            input = Console.ReadLine();
        }
    }
}

