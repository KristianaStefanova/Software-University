int age = int.Parse(Console.ReadLine());
double priceWashingMachine = double.Parse(Console.ReadLine());
int priceForOneToy = int.Parse(Console.ReadLine());

int lilySavedMoney = 0;
int counterToys = 0;
int moneyFromEvenBirthDay = 10;

for (int i = 1; i <= age; i++)
{
   
    if (i % 2 == 0)
    {
        lilySavedMoney += moneyFromEvenBirthDay - 1;
        moneyFromEvenBirthDay += 10;
    }
    else
    {
        counterToys++;
    }
}
int moneyFromToys = counterToys * priceForOneToy;
int finalMoney = moneyFromToys + lilySavedMoney;

if (finalMoney >= priceWashingMachine)
{
    double moneyLeft = finalMoney - priceWashingMachine;
    Console.WriteLine($"Yes! {moneyLeft:F2}");
}
else if (finalMoney < priceWashingMachine)
{
    double neededMoney = priceWashingMachine - finalMoney;
    Console.WriteLine($"No! {neededMoney:F2}");
}