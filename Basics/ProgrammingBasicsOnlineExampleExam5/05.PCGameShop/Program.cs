int hearthStoneCounter = 0;
int forniteCounter = 0;
int overWatchCounter = 0;
int othersCounter = 0;

int soledVideoGammes = int.Parse(Console.ReadLine());

for (int i = 0; i < soledVideoGammes; i++)
{
    string nameGame = Console.ReadLine();   

    if (nameGame == "Hearthstone")
    {
        hearthStoneCounter++;
    }
    else if (nameGame == "Overwatch")
    {
        overWatchCounter++;
    }
    else if (nameGame == "Fornite")
    {
        forniteCounter++;
    }
    else
    {
        othersCounter++;
    }
}

double percentHearthstone = hearthStoneCounter / (double)soledVideoGammes * 100;
double percentOverWatch = overWatchCounter / (double)soledVideoGammes * 100;
double percentFornite = forniteCounter / (double)soledVideoGammes * 100;
double percentOthers = othersCounter / (double)soledVideoGammes * 100;

Console.WriteLine($"Hearthstone - {percentHearthstone:F2}%");
Console.WriteLine($"Fornite - {percentFornite:F2}%");
Console.WriteLine($"Overwatch - {percentOverWatch:F2}%");
Console.WriteLine($"Others - {percentOthers:F2}%");