int count = int.Parse(Console.ReadLine());

int sumNum = 0;
double averageNum = 0;
for (int i = 0; i < count; i++)
{
    int number = int.Parse(Console.ReadLine());
    sumNum += number;
    averageNum = (double)sumNum / count;
}
Console.WriteLine($"{averageNum:F2}");