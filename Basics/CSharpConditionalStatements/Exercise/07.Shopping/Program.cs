//Income
double budget = double.Parse(Console.ReadLine());
int countVideoCard = int.Parse(Console.ReadLine());
int countProcessors = int.Parse(Console.ReadLine());
int countRamMemory = int.Parse(Console.ReadLine());

//Calculation
int priceForAllVideoCards = countVideoCard * 250;
double priceAllProssesors = (priceForAllVideoCards * 0.35) * countProcessors;
double priceAllRamMemory = (priceForAllVideoCards * 0.1) * countRamMemory;

double finalPrice = priceForAllVideoCards + priceAllProssesors + priceAllRamMemory;

if (countVideoCard > countProcessors)
{
    finalPrice = finalPrice - finalPrice * 0.15;
}

if (budget >= finalPrice)
{
    Console.WriteLine($"You have {budget - finalPrice:f2} leva left!");
}
else
{
    Console.WriteLine($"Not enough money! You need {finalPrice - budget:f2} leva more!");
}

