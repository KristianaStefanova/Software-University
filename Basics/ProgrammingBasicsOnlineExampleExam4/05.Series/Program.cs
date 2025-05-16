using System.ComponentModel.Design;

double budget = double.Parse(Console.ReadLine());
int countOfMovies = int.Parse(Console.ReadLine());
double finalPrice = 0;


for (int i = 0; i < countOfMovies; i++)
{
    string nameOfMovie = Console.ReadLine();  
    if (nameOfMovie == "Thrones")
    {
        double priceMovieThrones = double.Parse(Console.ReadLine());
        double finalPriceWithDiscount = priceMovieThrones * 0.5;
        finalPrice += finalPriceWithDiscount;
        continue;
    }
    else if (nameOfMovie == "Lucifer")
    {
        double priceMovieLucifer = double.Parse(Console.ReadLine());
        double finalPriceWithDiscount = priceMovieLucifer * 0.6;
        finalPrice += finalPriceWithDiscount;
        continue;
    }
    else if (nameOfMovie == "Protector")
    {
        double priceMovieProtector = double.Parse(Console.ReadLine());
        double finalPriceWithDiscount = priceMovieProtector * 0.70;
        finalPrice += finalPriceWithDiscount;
        continue;
    }
    else if (nameOfMovie == "TotalDrama")
    {
        double priceMovieTotalDrama = double.Parse(Console.ReadLine());
        double finalPriceWithDiscount = priceMovieTotalDrama * 0.8;
        finalPrice += finalPriceWithDiscount;
        continue;
    }
    else if (nameOfMovie == "Area")
    {
        double priceMovieArea = double.Parse(Console.ReadLine());
        double finalPriceWithDiscount = priceMovieArea * 0.9;
        finalPrice += finalPriceWithDiscount;
        continue;
    }
    double priceMovie = double.Parse(Console.ReadLine());
    finalPrice += priceMovie;
}

if (budget >= finalPrice)
{
    double moneyLeft = budget - finalPrice;
    Console.WriteLine($"You bought all the series and left with {moneyLeft:F2} lv.");
}
else if (budget < finalPrice)
{
    double neededMoney = finalPrice - budget;
    Console.WriteLine($"You need {neededMoney:F2} lv. more to buy the series!");
}