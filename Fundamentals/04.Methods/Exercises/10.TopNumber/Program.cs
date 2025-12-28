


class Program
{
    static void Main()
    {
        int end = int.Parse(Console.ReadLine());

        for (int i = 1; i <= end; i++)
        {
            if (TopNumber(i))
            {
                Console.WriteLine(i);
            }
        }
    }

    static bool TopNumber(int number)
    {
        if (IsDivisibleByEight(number) && HoldsOneOddDigit(number))
        {
            return true;
        }

        return false;
    }

    static bool HoldsOneOddDigit(int number)
    {
        while (number > 0)
        {
            int lastDigit = number % 10;
            if (lastDigit % 2 != 0)
            {
                return true;
            }
            number /= 10;
        }

        return false;
    }

    static bool IsDivisibleByEight(int number)
    {
        int sum = 0;

        while (number > 0)
        {
            int lastDigit = number % 10;
            sum += lastDigit;
            number /= 10;
        }
        if (sum % 8 == 0)
        {
            return true;
        }

        return false;
    }
}

