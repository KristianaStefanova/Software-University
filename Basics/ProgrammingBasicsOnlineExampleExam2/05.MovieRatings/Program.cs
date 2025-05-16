int countOfMovies = int.Parse(Console.ReadLine());

double maxRating = double.MinValue;
double minRating = double.MaxValue;

string nameMaxRating = "";
string nameMinxRating = "";
double totalRating = 0.0;

for (int i = 0; i < countOfMovies; i++)
{
    string nameOfMovie = Console.ReadLine();
    double raiting = double.Parse(Console.ReadLine());
    totalRating += raiting;
    if (raiting > maxRating)
    {
        maxRating = raiting;
        nameMaxRating = nameOfMovie;
    }
    else if (raiting < minRating)
    {
        minRating = raiting;
        nameMinxRating = nameOfMovie;
    }
}
Console.WriteLine($"{nameMaxRating} is with highest rating: {maxRating:F1}");
Console.WriteLine($"{nameMinxRating} is with lowest rating: {minRating:F1}");
double averageRaiting = totalRating / countOfMovies;
Console.WriteLine($"Average rating: {averageRaiting:F1}");
