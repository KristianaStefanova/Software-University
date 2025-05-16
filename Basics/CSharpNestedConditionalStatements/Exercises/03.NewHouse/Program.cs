

string kindOfFlower = Console.ReadLine();
int countOfFlowers = int.Parse(Console.ReadLine());
int budget = int.Parse(Console.ReadLine());

double finalPrice = 0;

switch (kindOfFlower)
{
    case "Roses":
        finalPrice = countOfFlowers * 5.0;

        if (countOfFlowers > 80)
        {
            finalPrice *= 0.9;
        }
        break;

    case "Dahlias":

        finalPrice = countOfFlowers * 3.80;

        if (countOfFlowers > 90)
        {
            finalPrice *= 0.85;
        }
        break;
    case "Tulips":

        finalPrice = countOfFlowers * 2.80;

        if (countOfFlowers > 80)
        {
            finalPrice *= 0.85;
        }
        break;
    case "Narcissus":
        finalPrice = countOfFlowers * 3;
        if (countOfFlowers < 120)
        {
            finalPrice = finalPrice + (finalPrice * 0.15);
        }
        break;
    case "Gladiolus":
        finalPrice = countOfFlowers * 2.5;
        if (countOfFlowers < 80)
        {
            finalPrice *= 1.20;
        }
        break;

}

double diff = Math.Abs(budget - finalPrice);

if (budget >= finalPrice)
{
    Console.WriteLine($"Hey, you have a great garden with {countOfFlowers} {kindOfFlower} and {diff:F2} leva left.");
}
else
{
    Console.WriteLine($"Not enough money, you need {diff:F2} leva more.");
}

