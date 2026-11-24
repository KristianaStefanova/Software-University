double budget = double.Parse(Console.ReadLine());
double moneyLeft = budget;
double totalMoneyToPay = 0;

double moneyLongName = 0;

while (true)
{
    string nameActor = Console.ReadLine();

    if (nameActor == "ACTION")
    {
        if (moneyLeft < 0)
        {
            Console.WriteLine($"We need {totalMoneyToPay - budget:F2} leva for our actors.");
            break;
        }
        else if (moneyLeft > 0)
        { 
            Console.WriteLine($"We are left with {moneyLeft:F2} leva.");
        }
    }
    int length = nameActor.Length;
    
    if (length > 15)
    {
        moneyLongName = moneyLeft * 0.2;
        moneyLeft -= moneyLongName;
        totalMoneyToPay += moneyLongName;
        continue;
    }
    double priceOneActor = double.Parse(Console.ReadLine());

    moneyLeft -= priceOneActor;
    totalMoneyToPay += priceOneActor;
   
    if (moneyLeft < 0)
    {
        Console.WriteLine($"We need {totalMoneyToPay-budget:F2} leva for our actors.");
        break;
    }
}




