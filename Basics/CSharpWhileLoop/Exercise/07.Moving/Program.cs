int freeSpaceWidth = int.Parse(Console.ReadLine());
int freeSpaceLength = int.Parse(Console.ReadLine());
int freeSpaceHeight = int.Parse(Console.ReadLine());

int ocupetedSpace = 0;

int volumeFreeSpace = freeSpaceHeight * freeSpaceLength * freeSpaceWidth;

while (volumeFreeSpace > 0)
{
    string input = Console.ReadLine();  

    if (input == "Done")
    {
        Console.WriteLine($"{volumeFreeSpace} Cubic meters left.");
        break;
    }
    int boxes = int.Parse(input);

    volumeFreeSpace -= boxes;
    ocupetedSpace += boxes;
}
if (volumeFreeSpace < 0)
{
    Console.WriteLine($"No more free space! You need {Math.Abs(volumeFreeSpace)} Cubic meters more.");
}
