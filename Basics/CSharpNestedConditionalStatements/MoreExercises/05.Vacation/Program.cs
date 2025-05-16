double budget = double.Parse(Console.ReadLine());
string season = Console.ReadLine();

string typeOfAccomodation = "";
string destination = "";
double money = 0.0;

if (budget <= 1000)
{
    typeOfAccomodation = "Camp";

    if (season == "Summer")
    {
        destination = "Alaska";
        money += budget *  0.65;

    }
    else if (season == "Winter")
    {
        destination = "Morocco";
        money += budget * 0.45;
    }

}
else if (budget > 1000 && budget <= 3000)
{
    typeOfAccomodation = "Hut";
    if (season == "Summer")
    {
        destination = "Alaska";
        money += budget * 0.80;

    }
    else if (season == "Winter")
    {
        destination = "Morocco";
        money += budget * 0.60;
    }
}
else if (budget > 3000)
{
    typeOfAccomodation = "Hotel";
    if (season == "Summer")
    {
        destination = "Alaska";
        money += budget * 0.90;

    }
    else if (season == "Winter")
    {
        destination = "Morocco";
        money += budget * 0.90;
    }
}
Console.WriteLine($"{destination} - {typeOfAccomodation} - {money:F2}");