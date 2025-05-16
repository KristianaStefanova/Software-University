int a1 = int.Parse(Console.ReadLine());
int a2 = int.Parse(Console.ReadLine());
int n = int.Parse(Console.ReadLine());
int fourth = 0;

for (int first = a1; first <= a2 - 1; first++)
{
    for (int second = 1; second <= n - 1; second++)
    {
        for (int third = 1; third <= n / 2 - 1; third++)
        {
            fourth = first;

            if (first % 2 != 0)
            {
                if ((second + third + fourth) % 2 != 0)
                {
                    Console.WriteLine($"{(char)first}-{second}{third}{fourth}");
                }
            }

        }
    }
}
