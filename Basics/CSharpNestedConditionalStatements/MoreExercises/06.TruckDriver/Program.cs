string season = Console.ReadLine();
double kilometers = double.Parse(Console.ReadLine());

double salary = 0.0;

switch (season)
{
    case "Spring":
    case "Autumn":
        if (kilometers <= 5000)
        {
            salary = kilometers * 0.75 * 4;
        }
        else if (kilometers <= 10000)
        {
            salary = kilometers * 0.95 * 4;
        }
        else if (kilometers <= 20000)
        {
            salary = kilometers * 1.45 * 4;
        }
        break;
    case "Summer":
        if (kilometers <= 5000)
        {
            salary = kilometers * 0.90 * 4;
        }
        else if (kilometers <= 10000)
        {
            salary = kilometers * 1.10 * 4;
        }
        else if (kilometers <= 20000)
        {
            salary = kilometers * 1.45 * 4;
        }
        break;
    case "Winter":
        if (kilometers <= 5000)
        {
            salary = kilometers * 1.05 * 4;
        }
        else if (kilometers <= 10000)
        {
            salary = kilometers * 1.25 * 4;
        }
        else if (kilometers <= 20000)
        {
            salary = kilometers * 1.45 * 4;
        }
        break;
}

salary *= 0.90;

Console.WriteLine($"{salary:F2}");