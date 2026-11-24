int n = int.Parse(Console.ReadLine());

int counter = 0 ;
bool flag = false;
for (int row = 1; row <= n; row++)
{
    for (int j = 1; j <= row; j++)
    {
        counter++;
        if (counter > n)
        {
            flag = true;
            break;
        }
        Console.Write(counter + " ");
    }
    Console.WriteLine();
    if (flag)
    {
        break;
    }
}