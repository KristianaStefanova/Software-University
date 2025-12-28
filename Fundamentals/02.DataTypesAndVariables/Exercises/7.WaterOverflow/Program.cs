class Program
{
    static void Main(string[] args)
    {
        int counter = int.Parse(Console.ReadLine());

        int capacity = 255;
        int quantity = 0;

        for (int i = 0; i < counter; i++)
        {
            int litters = int.Parse(Console.ReadLine());

            if (quantity + litters > capacity)
            {
                Console.WriteLine("Insufficient capacity!");
                continue;
            }

            quantity += litters;
        }

        Console.WriteLine(quantity);
    }
}

