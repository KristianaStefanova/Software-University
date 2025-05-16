double inheritance = double.Parse(Console.ReadLine());
double moneyLeft = inheritance;
int endYear = int.Parse(Console.ReadLine());
double allMoney = 0;

int age = 18;

for (int i = 1800; i <= endYear; i++)
{
    if (i % 2 == 0)
    {
        moneyLeft -= 12000;
        age++;
        allMoney += 12000;
    }
    else
    {
        moneyLeft -= 12000 + 50 * age;
        age++;
        allMoney += 12000 + 50 * age;
    }
}
if (moneyLeft >= 0)
{
    Console.WriteLine($"Yes! He will live a carefree life and will have {moneyLeft:F2} dollars left.");
}
else
{
    double neededMoney = Math.Abs(moneyLeft);
    Console.WriteLine($"He will need {neededMoney:F2} dollars to survive.");
}