string fruit = Console.ReadLine();
string size = Console.ReadLine();
int countOfSets = int.Parse(Console.ReadLine());

double finalPrice = 0.0;

if (fruit == "Watermelon")
{
    if (size == "small")
    {
        finalPrice = 56 * 2 * countOfSets;
    }
    else if (size == "big")
    {
        finalPrice = 28.70 * 5 * countOfSets;
    }
}
else if (fruit == "Mango")
{
    if (size == "small")
    {
        finalPrice = 36.66 * 2 * countOfSets;
    }
    else if (size == "big")
    {
        finalPrice = 19.60 * 5 * countOfSets;
    }
}
else if (fruit == "Pineapple")
{
    if (size == "small")
    {
        finalPrice = 42.10 * 2 * countOfSets;
    }
    else if (size == "big")
    {
        finalPrice = 24.80 * 5 * countOfSets;
    }
}
else if (fruit == "Raspberry")
{
    if (size == "small")
    {
        finalPrice = 20 * 2 * countOfSets;
    }
    else if (size == "big")
    {
        finalPrice = 15.20 * 5 * countOfSets;
    }
}

if (finalPrice >= 400 && finalPrice <= 1000)
{
    finalPrice *= 0.85;
}
else if (finalPrice > 1000)
{
    finalPrice *= 0.5;
}
Console.WriteLine($"{finalPrice:F2} lv.");