int age = int.Parse(Console.ReadLine());
double priceWashingMachine = double.Parse(Console.ReadLine());
int pricePerToy = int.Parse(Console.ReadLine());

int counterToys = 0;
int savedMoney = 0;
int evenBirghtday = 10;

for (int i = 1; i <= age; i++)
{
    if (i % 2 == 0)
    {
        savedMoney += evenBirghtday - 1;
        evenBirghtday += 10;
    }
    else
    {
        counterToys++;
    }
}
int moneyFromToys = counterToys * pricePerToy;
int allSavedMoney = moneyFromToys + savedMoney;

if (allSavedMoney >= priceWashingMachine)
{
    double moneyLeft = allSavedMoney - priceWashingMachine;
    Console.WriteLine($"Yes! {moneyLeft:F2}");
}
else
{
    double neededMoney = priceWashingMachine - allSavedMoney;
    Console.WriteLine($"No! {neededMoney:F2}");
}