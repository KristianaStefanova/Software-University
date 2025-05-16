double priceBaggageOver20 = double.Parse(Console.ReadLine());   
int kilogramsOfBaggage  = int.Parse(Console.ReadLine());
int daysLeft = int.Parse(Console.ReadLine());   
int countOfBaggage  = int.Parse(Console.ReadLine());

double priceBaggage = 0.0;
double priceBaggageUnder10 = 0.0;

if (kilogramsOfBaggage < 10)
{
    priceBaggage = priceBaggageOver20 * 0.2;
}
else if (kilogramsOfBaggage >= 10 && kilogramsOfBaggage <= 20)
{
    priceBaggage = priceBaggageOver20 * 0.5;
}
else if (kilogramsOfBaggage > 20)
{
    priceBaggage = priceBaggageOver20;
}

if (daysLeft > 30)
{
    priceBaggage *= 1.1;
}
else if (daysLeft >= 7 && daysLeft <= 30)
{
    priceBaggage *= 1.15;
}
else if (daysLeft < 7)
{
    priceBaggage *= 1.4;
}

priceBaggage = priceBaggage * countOfBaggage;

Console.WriteLine($"The total price of bags is: {priceBaggage:F2} lv. ");