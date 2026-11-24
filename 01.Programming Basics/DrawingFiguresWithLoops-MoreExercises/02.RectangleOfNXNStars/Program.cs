int number = int.Parse(Console.ReadLine());
for (int row = 1; row <= number; row++)
{
    for (int cow = 1; cow <= number; cow++)
    {
        Console.Write("*");
    }
    Console.WriteLine();
}