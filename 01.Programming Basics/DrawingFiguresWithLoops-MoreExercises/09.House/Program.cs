int n = int.Parse(Console.ReadLine());

int stars = 1;


if (n % 2 == 0)
{
    stars = 2;
}
for (int i = 0; i < (n+1)/2; i++)
{
    int hyphens = (n - stars) / 2;
    Console.Write(new string('-', hyphens));
    Console.Write(new string('*', stars));
    Console.Write(new string('-', hyphens));

    Console.WriteLine();
    stars += 2;
}
for (int row = 0; row < n/2; row++)
{
    Console.Write("|");
    Console.Write(new string('*', n - 2));
    Console.Write("|");
    Console.WriteLine();
}