using System.Diagnostics.Metrics;

class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int sum = 0;
        int i = 0;
        int counter = 0;

        while (counter < number)
        {
            i++;

            if (i % 2 != 0)
            {
                Console.WriteLine(i);
                sum += i;
                counter++;
            }
        }
        Console.WriteLine($"Sum: {sum}");
    }
}

