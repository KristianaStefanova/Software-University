using System.Runtime.InteropServices;

double budget =double.Parse(Console.ReadLine());
string season =Console.ReadLine();

string clas = "";
double money = 0.0;
string typeOfCar = "";

if (budget <= 100)
{
    clas = "Economy class";
    if (season == "Summer")
    {
        money += budget * 0.35;
        typeOfCar = "Cabrio";
    }
    else if (season == "Winter")
    {
        money += budget * 0.65;
        typeOfCar = "Jeep";
    }
}
else if (budget > 100 && budget <= 500)
{
    clas = "Compact class";
    if (season == "Summer")
    {
        money += budget * 0.45;
        typeOfCar = "Cabrio";
    }
    else if (season == "Winter")
    {
        money += budget * 0.80;
        typeOfCar = "Jeep";
    }
}
else if (budget > 500)
{
    clas = "Luxury class";

    money += budget * 0.90;
    typeOfCar = "Jeep";
}

Console.WriteLine(clas);
Console.WriteLine($"{typeOfCar} - {money:F2}");