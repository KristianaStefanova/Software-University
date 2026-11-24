int n = int.Parse(Console.ReadLine());

int mid = -1;

if (n % 2 == 0)
{
    mid = 0;
}

for (int row = 1; row <= (n + 1) / 2; row++)
{
    int leftAndRight = (n - 2 - mid) / 2;
    Console.Write(new string('-', leftAndRight));
    Console.Write("*");
    if (mid >= 0)
    {
        Console.Write(new string('-', mid));
        Console.Write("*");
    }
    Console.Write(new string('-', leftAndRight));
    Console.WriteLine();
    mid += 2;
}


mid = n - 4;

for (int row = 1; row < (n + 1) / 2; row++)
{
    int leftAndRight = (n - 2 - mid) / 2;
    Console.Write(new string('-', leftAndRight));
    Console.Write("*");
    if (mid >= 0)
    {
        Console.Write(new string('-', mid));
        Console.Write("*");
    }
    Console.Write(new string('-', leftAndRight));
    Console.WriteLine();
    mid -= 2;
}