double budget = double.Parse(Console.ReadLine());
string season = Console.ReadLine();

string destination = "";
double moneySpended = 0;
string acommodation = "";

if (budget <= 100)
{
    destination = "Bulgaria";
    switch (season)
    {
        case "summer":
            moneySpended = budget * 0.30;
            acommodation = "Camp";
            break;
        case "winter":
            moneySpended = budget * 0.70;
            acommodation = "Hotel";
            break;
    }
}


else if (budget <= 1000)
{
    destination = "Balkans";
    switch (season)
    {
        case "summer":
            moneySpended = budget * 0.40;
            acommodation = "Camp";
            break;
        case "winter":
            moneySpended = budget * 0.80;
            acommodation = "Hotel";
            break;
    }
}
else
{
    destination = "Europe";
    switch (season)
    {
        case "summer":
        case "winter":
            moneySpended = budget * 0.90;
            acommodation = "Hotel";
            break;
    }
}
Console.WriteLine($"Somewhere in {destination}");
Console.WriteLine($"{acommodation} - {moneySpended:F2}");


