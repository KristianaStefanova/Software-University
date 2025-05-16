int n = int.Parse(Console.ReadLine());

for (int row = 0; row < n; row++)
{
    Console.Write("*");

    for (int col = 0; col < n-1;      col++)
    {
        Console.Write(" *");
    }

    Console.WriteLine();
}