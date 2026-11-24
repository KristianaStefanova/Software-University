int h = int.Parse(Console.ReadLine());
int x = int.Parse(Console.ReadLine());
int y = int.Parse(Console.ReadLine());

bool outSide1 = (x < h || x > 2 * h) || (y > h * 4 || y < h);
bool outSide2 = (x < 0 || x > 3*h) || (y < 0 || y > h);
bool inSide1 = (x > h && x < 2*h) && (y > h && y < 4 * h);
bool inSide2 = (x > 0 && x < 3*h) && (y > 0 && y < h);
bool border = (x > h && x < 2*h) && (y == h);

if (outSide1 && outSide2 )
{
    Console.WriteLine("outside");
}
else if (inSide1 || inSide2 || border)
{
    Console.WriteLine("inside");
}
else
{
    Console.WriteLine("border");
}