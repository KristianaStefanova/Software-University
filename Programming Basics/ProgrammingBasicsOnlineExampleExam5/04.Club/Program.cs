double minIncome = double.Parse(Console.ReadLine()); 
string nameCoctel = Console.ReadLine();

double priceCoctel = 0;
double totalIncome = 0.0;
while (totalIncome < minIncome)
{
    if (nameCoctel == "Party!")
    {
        double neededMoney = minIncome - totalIncome;
        Console.WriteLine($"We need {neededMoney:F2} leva more.");
        Console.WriteLine($"Club income - {totalIncome:F2} leva.");
        break;
    }

    int countOfCoctails = int.Parse(Console.ReadLine());

    priceCoctel = nameCoctel.Length;

    double priceFromCoctails = priceCoctel * countOfCoctails;

    int lastNum = (int)priceFromCoctails % 10;

    if (lastNum % 2 != 0)
    {
        priceFromCoctails *= 0.75;
    }

    totalIncome += priceFromCoctails;

    nameCoctel = Console.ReadLine();
}

if (minIncome <= totalIncome)
{
    Console.WriteLine("Target acquired.");
    Console.WriteLine($"Club income - {totalIncome:F2} leva.");
}