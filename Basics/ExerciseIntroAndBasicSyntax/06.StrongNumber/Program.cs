class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int copyNumber = number;
        int factorialSum = 0;

        while (copyNumber > 0)
        {
            int digit = copyNumber % 10;
            copyNumber /= 10;

            int facorial = 1;
            for (int i = 1; i <= digit; i++)
            {

                facorial *= i;
            }
            factorialSum += facorial;
        }
        bool isStrongNumber = factorialSum == number;

        Console.WriteLine(isStrongNumber ? "yes" : "no");

    }
}

