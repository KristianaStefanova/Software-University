double totalMoney = double.Parse(Console.ReadLine());
int endingYear  = int.Parse(Console.ReadLine());
int moneyToLive = 0;

for (int i = 1800; i <= endingYear; i++)
{
    moneyToLive += 12000;
    if (i % 2 != 0)
    {
        moneyToLive += 50;
    }
}
if (totalMoney >= moneyToLive)
{
    double moneyLeft = totalMoney - moneyToLive;
    Console.WriteLine($"Yes! He will live a carefree life and will have {moneyLeft:F2} dollars left.");
}
else
{
    double neededMoney = moneyToLive - totalMoney;
    Console.WriteLine($"He will need {neededMoney:F2} dollars to survive.");
}