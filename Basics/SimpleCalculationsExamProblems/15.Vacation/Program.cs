double budget = double.Parse(Console.ReadLine());
string season = Console.ReadLine();
double finalSum = 0.0;
string destination = "";
string kindOfTrip = "";

if (budget > 1000)
{
    finalSum = budget * 0.9;
    destination = "Europe";
    kindOfTrip = "Hotel";
}
else if (budget <= 100)
{
    destination = "Bulgaria";

    switch (season)
    {
        case "summer":
            finalSum = budget * 0.3;
            kindOfTrip = "Camp";
            break;
        case "winter":
            finalSum = budget * 0.7;
            kindOfTrip = "Hotel";
            break;
    }
}
else if (budget <= 1000)
{
    destination = "Balkans";

    switch (season)
    {
        case "summer":
            finalSum = budget * 0.4;
            kindOfTrip = "Camp";
            break;
        case "winter":
            finalSum = budget * 0.8;
            kindOfTrip = "Hotel";
            break;
    }
}

Console.WriteLine($"Somewhere in {destination}");
Console.WriteLine($"{kindOfTrip} – {finalSum:F2}");