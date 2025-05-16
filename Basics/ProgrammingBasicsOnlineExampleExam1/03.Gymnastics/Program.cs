string country = Console.ReadLine();
string appliance = Console.ReadLine();

double assessment = 0;

if (country == "Russia")
{
    switch (appliance)
    {
        case "ribbon":
            assessment = 9.100 + 9.400;
            break;
        case "hoop":
            assessment = 9.300 + 9.800;
            break;
        case "rope":
        default:
            assessment = 9.600 + 9.000;
            break;
    }
}
else if (country == "Bulgaria")
{
    switch (appliance)
    {
        case "ribbon":
            assessment = 9.600 + 9.400;
            break;
        case "hoop":
            assessment = 9.550 + 9.750;
            break;
        case "rope":
        default:
            assessment = 9.500 + 9.400;
            break;
    }
}
else if (country == "Italy")
{
    switch (appliance)
    {
        case "ribbon":
            assessment = 9.200 + 9.500;
            break;
        case "hoop":
            assessment = 9.450 + 9.350;
            break;
        case "rope":
        default:
            assessment = 9.700 + 9.150;
            break;
    }
}
double neededPoints = 20 - assessment;
double neededPercent = (neededPoints / 20) * 100;

Console.WriteLine($"The team of {country} get {assessment:F3} on {appliance}.");
Console.WriteLine($"{neededPercent:F2}%");
