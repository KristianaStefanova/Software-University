using System.Transactions;

double moneyForTrip = double.Parse(Console.ReadLine());
double savedMoney = double.Parse(Console.ReadLine());

int dayCounter = 0;
int spendCounter = 0;

while (moneyForTrip > savedMoney)
{
    string whatJessyDo = Console.ReadLine();
    double moneyPerDay = double.Parse(Console.ReadLine());

    dayCounter++;
    
    if (whatJessyDo == "spend")
    {
        spendCounter++;
        savedMoney -= moneyPerDay;

        if (savedMoney < 0)
        {
            savedMoney = 0;
        } 
        if (spendCounter == 5)
        {
            Console.WriteLine($"You can't save the money.");
            Console.WriteLine(dayCounter);
            break;
        }
    }
    else if (whatJessyDo == "save")
    {
        savedMoney += moneyPerDay;
        spendCounter = 0;
    }
}
if (savedMoney >= moneyForTrip)
{
    Console.WriteLine($"You saved the money for {dayCounter} days.");
}

