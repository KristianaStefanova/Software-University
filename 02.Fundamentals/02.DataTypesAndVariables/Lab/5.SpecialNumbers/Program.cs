class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());

        for (int i = 1; i <= count; i++)
        {
            int currentNum = i;
            int sum = 0;

            while (currentNum != 0)
            {
                int digit = currentNum % 10;
                currentNum /= 10;
                sum += digit;
            }

            if (sum == 5 || sum == 7 || sum == 11)
            {
                Console.WriteLine($"{i} -> True");
            }
            else
            {
                Console.WriteLine($"{i} -> False");
            }
        }
    }
}

