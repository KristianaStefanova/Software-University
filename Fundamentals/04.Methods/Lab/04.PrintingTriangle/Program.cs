


class Program
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());

        PrintLeftSideTriangle(height);
        PrintHeightTriangle(height);
        PrintRightSideTriangle(height);
    }

    private static void PrintLeftSideTriangle(int height)
    {
        for (int row = 1; row < height; row++)
        {
            for(int coll = 1; coll <= row; coll++)
            {
                Console.Write(coll + " ");
            }

            Console.WriteLine();
        }
    }

    private static void PrintHeightTriangle(int height)
    {
        for (int i = 1; i <= height; i++)
        {
            Console.Write(i + " ");
        }

        Console.WriteLine();
    }
    private static void PrintRightSideTriangle(int height)
    {
        for (int row = height - 1; row >= 0; row--)
        {
            for (int coll = 1; coll <= row; coll++)
            {
                Console.Write(coll + " ");
            }

            Console.WriteLine();
        }
    }
}

