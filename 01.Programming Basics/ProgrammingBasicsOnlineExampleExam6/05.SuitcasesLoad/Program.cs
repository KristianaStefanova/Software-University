double trunkSpace = double.Parse(Console.ReadLine());

double ocuppatedSpace = 0;
int counterBaggage = 0;
bool isFull = false;

string input = Console.ReadLine();

while (input != "End")
{
    double size = double.Parse(input);
    counterBaggage++;

    if (counterBaggage % 3 == 0)
    {
        size *= 1.1;
    }

    ocuppatedSpace += size;

    if (ocuppatedSpace > trunkSpace)
    {
        isFull = true;
        break;
    }

    input = Console.ReadLine();
}
if (trunkSpace >= ocuppatedSpace)
{
    Console.WriteLine("Congratulations! All suitcases are loaded!");
}
else
{
    Console.WriteLine($"No more space!");
}

if (isFull)
{
    Console.WriteLine($"Statistic: {counterBaggage - 1} suitcases loaded.");
}
else
{
    Console.WriteLine($"Statistic: {counterBaggage} suitcases loaded.");
}

