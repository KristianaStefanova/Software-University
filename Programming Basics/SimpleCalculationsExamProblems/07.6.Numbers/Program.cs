int n = int.Parse(Console.ReadLine());

int firstDigit = (n / 100) % 10;
int secondDigit = (n / 10) % 10;
int thirdDigit = n % 10;

for (int row = 1; row <= firstDigit + secondDigit; row++)
{
    for (int cow = 1; cow <= firstDigit + thirdDigit; cow++)
    {
        if (n % 5 == 0)
        {
            n -= firstDigit;
        }
        else if (n % 3 == 0)
        {
            n -= secondDigit;
        }
        else
        {
            n  = thirdDigit;
        }

        Console.Write(n + " ");
    }

    Console.WriteLine();
}