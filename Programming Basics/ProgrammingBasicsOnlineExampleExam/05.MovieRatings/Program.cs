int countOfMoovies = int.Parse(Console.ReadLine());

double maxRating = double.MinValue;
double minRating = double.MaxValue;
string nameMaxRating = "";
string nameMinRating = "";

double sumAllRating = 0.0;

for (int i = 1; i <= countOfMoovies; i++)
{
    string nameOfMovie = Console.ReadLine();
    double rating = double.Parse(Console.ReadLine());

    sumAllRating += rating;

    if (rating > maxRating)
    {
        maxRating = rating;
        nameMaxRating = nameOfMovie;

    }
    if (rating < minRating)
    {
        minRating = rating;
        nameMinRating = nameOfMovie;
    }
}
double percentAverigeRating = sumAllRating / countOfMoovies;

Console.WriteLine($"{nameMaxRating} is with highest rating: {maxRating:F1}");
Console.WriteLine($"{nameMinRating} is with lowest rating: {minRating:F1}");
Console.WriteLine($"Average rating: {percentAverigeRating:F1}");