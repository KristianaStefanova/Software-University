class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int multiplier = int.Parse(Console.ReadLine());
        int result = 1;
        int counter = multiplier;

        while (true)
        {
            if (multiplier > 10)
            {
                result = multiplier * n;
                Console.WriteLine($"{n} X {multiplier} = {result}");
                return;
            }

            result = n * counter;
            Console.WriteLine($"{n} X {counter} = {result}");
            counter++;
            if (counter > 10)
            {
                break;
            }
        }
    }
}

