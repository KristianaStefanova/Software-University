int x1 = int.Parse(Console.ReadLine());
int y1 = int.Parse(Console.ReadLine());
int x2 = int.Parse(Console.ReadLine());
int y2 = int.Parse(Console.ReadLine());
int x3 = int.Parse(Console.ReadLine());
int y3 = int.Parse(Console.ReadLine());

int a = x2 - x3;
int h = y2 - y1;

double area = (double)a * h / 2;

Console.WriteLine($"{area}");

for (int i = 0; i < a; i++)
{
    Console.WriteLine(i);
}