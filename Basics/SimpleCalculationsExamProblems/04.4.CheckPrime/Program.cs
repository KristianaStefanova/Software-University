int n = int.Parse(Console.ReadLine());

bool prime = (n > 1);

for (int i = 2; i <= Math.Sqrt(n); i++)
{
    if (n % i == 0)
    {

        prime = false;

        break;
    }
}

if (prime)
{
    Console.WriteLine("prime");
}
else
{
    Console.WriteLine("not prime");
}