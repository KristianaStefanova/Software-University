class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());

        int[] ints = new int[count];

        for (int row = 1; row <= count; row++)
        {
            for (int col = 1; col <= row; col++)
            {

                Console.Write(0 + " ");
            }

            Console.WriteLine();
        }
    }
}

