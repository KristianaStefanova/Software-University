int expectedMoney = int.Parse(Console.ReadLine());

int neededMoney = expectedMoney;
int counterCash = 1;
int counterCard = 0;
int countOfPeopleCard = 0;
int countOfPeopleCash = 0;
int sumCard = 0;
int sumCash = 0;

while (neededMoney > 0)
{
    string text = Console.ReadLine();
    if (text == "End")
    {
        if (neededMoney > 0)
        {
            Console.WriteLine($"Failed to collect required money for charity.");
            break;
        }
    } 
    
    int price = int.Parse(text);

    if (counterCash == 1)
    {
        if (price > 100)
        {
            Console.WriteLine("Error in transaction!");
        }
        else 
        {
            neededMoney -= price;
            countOfPeopleCash++;
            sumCash += price;
            Console.WriteLine("Product sold!");
        }
        counterCash = 0;
        counterCard = 1;
    }

    else if (counterCard == 1)
    {
        if (price < 10)
        {   
            Console.WriteLine("Error in transaction!");
        }
        else 
        {
            neededMoney -= price;
            countOfPeopleCard++;
            sumCard += price;
            Console.WriteLine("Product sold!");
        }
    
        counterCash = 1;
        counterCard = 0;
    }
   
    if (neededMoney <= 0)
    {
        double averageCash = sumCash / (double)countOfPeopleCash;
        double averageCard = sumCard / (double)countOfPeopleCard;
        Console.WriteLine($"Average CS: {averageCash:F2}");
        Console.WriteLine($"Average CC: {averageCard:F2}");
        return;
    }
}





