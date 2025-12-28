
class Program
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());

        PrintNxX(number);
    }

    private static void PrintNxX(int number)
    {
        for (int row = 0; row < number; row++)
        {
            for (int coll = 0; coll < number; coll++)
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();
        }
    }
}

