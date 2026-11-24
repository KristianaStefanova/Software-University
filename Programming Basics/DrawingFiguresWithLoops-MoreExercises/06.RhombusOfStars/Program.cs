int n = int.Parse(Console.ReadLine());

for (int row = 1; row <= n; row++)
{
    for (int i = 1; i <= n - row; i++)
    {
        Console.Write(" ");
    }
    for (int col = 1; col <= row; col++)
    {
        Console.Write("* ");
    }
    Console.WriteLine();
}

for (int row = n - 1; row >= 1; row--)
{

    for (int i = 1; i <= n - row; i++)
    {
        Console.Write(" ");
    } 

 for( int col = 1; col <= row; col++)
    {
        
        Console.Write("* ");
    }
    Console.WriteLine();
}
