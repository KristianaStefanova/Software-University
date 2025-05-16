string namePlayer = Console.ReadLine();

int counterShots = 0;
int wrongShots = 0;
int restPoints = 301;

for (int i = restPoints; restPoints > 0; i--)
{
    string text = Console.ReadLine();
    if (text == "Retire")
    {
        Console.WriteLine($"{namePlayer} retired after {wrongShots} unsuccessful shots.");
        break;
    }
    int points = int.Parse(Console.ReadLine());
   
    if ( text == "Single")
    {
        if (points <= restPoints)
        {
        restPoints -= points;
            counterShots++;

        }
        else
        {
            wrongShots++;
        }
    }
    else if (text == "Double")
    {
        if (points * 2 <= restPoints)
        {
            restPoints -= points * 2;
            counterShots++;
        }
        else
        {
            wrongShots++;
        }
    }
    else if (text == "Triple")
    {
        if (points * 3 <= restPoints)
        {
            restPoints -= points * 3;
            counterShots++;
        }
        else 
        {
            wrongShots++;
        }
    }
}

if (restPoints == 0)
{
    Console.WriteLine($"{namePlayer} won the leg with {counterShots} shots.");
}