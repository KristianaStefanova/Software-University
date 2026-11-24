int allSeats = int.Parse(Console.ReadLine());
int numOfFans = int.Parse(Console.ReadLine());

int counterA = 0;
int counterB = 0;
int counterV = 0;
int counterG = 0;

for (int i = 0; i < numOfFans; i++)
{
    char sector = char.Parse(Console.ReadLine());

    if(sector == 'A')
    {
        counterA++;
    }
    else if (sector == 'B')
    {
        counterB++;
    }
    else if (sector == 'V')
    {
        counterV++;
    }
    else if (sector == 'G')
    {
        counterG++;
    }
}
double percentA = counterA / (double)numOfFans * 100;
double percentB = counterB / (double)numOfFans * 100;
double percentV = counterV / (double)numOfFans * 100;
double percentG = counterG / (double)numOfFans * 100;

double percentFull = numOfFans / (double)allSeats * 100;

Console.WriteLine($"{percentA:F2}%");
Console.WriteLine($"{percentB:F2}%");
Console.WriteLine($"{percentV:F2}%");
Console.WriteLine($"{percentG:F2}%");
Console.WriteLine($"{percentFull:F2}%");

