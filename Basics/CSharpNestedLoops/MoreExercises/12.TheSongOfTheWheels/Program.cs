int sum = int.Parse(Console.ReadLine());
bool isFound = false;
int counter = 0;
int firstNum = 0;
int secondtNum = 0;
int thirdNum = 0;
int fourthNum = 0;

for (int a = 1; a <= 9; a++)
{
    for (int b = 1; b <= 9; b++)
    {
        for (int c = 1; c <= 9; c++)
        {
            for (int d = 1; d <= 9; d++)
            {
                if ((a < b && c > d) && a * b + c * d == sum)
                {
                    Console.Write($"{a}{b}{c}{d} ");
                    counter++;
                    if (counter == 4)
                    {
                        firstNum = a;
                        secondtNum = b;
                        thirdNum = c;
                        fourthNum = d;
                    }
                    isFound = true;

                }
            }
        }
    }
}

if (!isFound)
{
    Console.WriteLine("No!");
}
else
{
    Console.WriteLine();
    Console.Write($"Password: {firstNum}{secondtNum}{thirdNum}{fourthNum}");
}