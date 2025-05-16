int numOfEggs = int.Parse(Console.ReadLine());

int counterRed = 0;
int counterOrange = 0;
int counterBlue = 0;
int counterGreen = 0;
string colour = "";

int maxEggs = 0;

for (int i = 0; i < numOfEggs; i++)
{
    string color = Console.ReadLine();  

    if (color == "red")
    {
        counterRed++;
        if (counterRed > counterBlue && counterRed > counterOrange && counterRed > counterGreen)
        {
            maxEggs = counterRed;
        }
    }
    else if (color == "orange")
    {
        counterOrange++;
        if (counterOrange > counterBlue && counterOrange > counterGreen && counterOrange > counterRed)
        {
            maxEggs = counterOrange;
        }
    }
    else if (color == "blue")
    {
        counterBlue++;
        if (counterBlue > counterGreen && counterBlue > counterOrange && counterBlue > counterRed)
        {
            maxEggs = counterBlue;
        }
    }
    else if (color == "green")
    {
        counterGreen++;
        if (counterGreen > counterBlue && counterGreen > counterOrange && counterGreen > counterRed)
        {
            maxEggs = counterGreen;
        }
    }
}
if (maxEggs == counterRed)
{
    Console.WriteLine($"Red eggs: {counterRed}");
    Console.WriteLine($"Orange eggs: {counterOrange}");
    Console.WriteLine($"Blue eggs: {counterBlue}");
    Console.WriteLine($"Green eggs: {counterGreen}");
    Console.WriteLine($"Max eggs: {maxEggs} -> red");
}
else if (maxEggs == counterOrange)
{
    Console.WriteLine($"Red eggs: {counterRed}");
    Console.WriteLine($"Orange eggs: {counterOrange}");
    Console.WriteLine($"Blue eggs: {counterBlue}");
    Console.WriteLine($"Green eggs: {counterGreen}");
    Console.WriteLine($"Max eggs: {maxEggs} -> orange");
}
else if (maxEggs == counterBlue)
{
    Console.WriteLine($"Red eggs: {counterRed}");
    Console.WriteLine($"Orange eggs: {counterOrange}");
    Console.WriteLine($"Blue eggs: {counterBlue}");
    Console.WriteLine($"Green eggs: {counterGreen}");
    Console.WriteLine($"Max eggs: {maxEggs} -> blue");
}
else if (maxEggs == counterGreen)
{
    Console.WriteLine($"Red eggs: {counterRed}");
    Console.WriteLine($"Orange eggs: {counterOrange}");
    Console.WriteLine($"Blue eggs: {counterBlue}");
    Console.WriteLine($"Green eggs: {counterGreen}");
    Console.WriteLine($"Max eggs: {maxEggs} -> green");
}
