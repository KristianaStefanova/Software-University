using System.ComponentModel.Design;

class Program
{
    static void Main(string[] args)
    {
        int counter = int.Parse(Console.ReadLine());

        for (int digit = 1; digit <= counter; digit++)
        {
            int currentNumber = digit;
            int sum = 0;

            while (currentNumber > 0)
            {
                sum += currentNumber % 10;
                currentNumber /= 10;
            }

            bool isSpecial = (sum == 5 || sum == 7 || sum == 11);

            Console.WriteLine($"{digit} -> {isSpecial}");
           
            sum = 0;
        }
    }
}

