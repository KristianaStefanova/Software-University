string country = Console.ReadLine();
string applinaoe = Console.ReadLine();

double allPoints = 0.0;


switch (country)
{
    case "Russia": 
        if (applinaoe == "ribbon")
        {
            allPoints = 9.100 + 9.400;
        }
        else if (applinaoe == "hoop")
        {
            allPoints = 9.300 + 9.800;
        }
        else if (applinaoe == "rope")
        {
            allPoints = 9.000 + 9.600;
        }
        break;
    case "Bulgaria":
        if (applinaoe == "ribbon")
        {
            allPoints = 9.600 + 9.400;
        }
        else if (applinaoe == "hoop")
        {
            allPoints = 9.550 + 9.750;
        }
        else if (applinaoe == "rope")
        {
            allPoints = 9.500 + 9.400;
        }
        break;
    case "Italy":
        if (applinaoe == "ribbon")
        {
            allPoints = 9.200 + 9.500;
        }
        else if (applinaoe == "hoop")
        {
            allPoints = 9.450 + 9.350;
        }
        else if (applinaoe == "rope")
        {
            allPoints = 9.700 + 9.150;
        }
        break;
}
double neededPoints = 20 - allPoints;
double percentNeededPoints = neededPoints / 20 * 100;

Console.WriteLine($"The team of {country} get {allPoints:F3} on {applinaoe}");
Console.WriteLine($"{percentNeededPoints:F2}%");