int countOFGroups = int.Parse(Console.ReadLine());

int musala = 0;
int monblan = 0;
int kalimadjarovo = 0;
int k2 = 0;
int everest = 0;

for (int group = 1; group <= countOFGroups; group++)
{
    int countOfPeople = int.Parse(Console.ReadLine());  

    if (countOfPeople <= 5)
    {
        musala += countOfPeople;
    }
    else if (countOfPeople >= 6 && countOfPeople <= 12)
    {
        monblan += countOfPeople;
    }
    else if (countOfPeople >= 13 && countOfPeople <= 25)
    {
        kalimadjarovo += countOfPeople;
    }
    else if (countOfPeople >= 26 && countOfPeople <= 40)
    {
        k2 += countOfPeople;
    }
    else if (countOfPeople >= 41)
    {
        everest += countOfPeople;
    }
}
double totalPeople = musala + monblan+ kalimadjarovo + k2 + everest;    

double percentMusala = (double)musala / totalPeople * 100;
double percentMonblan = (double)monblan / totalPeople * 100;
double percentKalimadjarovo = (double)kalimadjarovo / totalPeople * 100;
double percentK2 = (double)k2 / totalPeople * 100;
double percentEverest = (double)everest / totalPeople * 100;

Console.WriteLine($"{percentMusala:F2}%");
Console.WriteLine($"{percentMonblan:F2}%");
Console.WriteLine($"{percentKalimadjarovo:F2}%");
Console.WriteLine($"{percentK2:F2}%");
Console.WriteLine($"{percentEverest:F2}%");