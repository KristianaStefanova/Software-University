using System.Diagnostics;

string city = Console.ReadLine();
double s = double.Parse(Console.ReadLine());

double comission = 0;
bool invalidInput = false;

if (s < 0)
{
    invalidInput = true;
}
else if (s <= 500)
{
    switch (city)
    {
        case "Sofia":
            comission = s * 0.05;
            break;
        case "Varna":
            comission = s * 0.045;
            break;
        case "Plovdiv":
            comission = s * 0.055;
            break;
        default:
            invalidInput = true;
            break;
    }
}
else if (s <= 1000)
{
    switch (city)
    {
        case "Sofia":
            comission = s * 0.07;
            break;
        case "Varna":
            comission = s * 0.075;
            break;
        case "Plovdiv":
            comission = s * 0.08;
            break;
        default:

            invalidInput = true;
            break;
    }
}
else if (s <= 10000)
{
    switch (city)
    {
        case "Sofia":
            comission = s * 0.08;
            break;
        case "Varna":
            comission = s * 0.10;
            break;
        case "Plovdiv":
            comission = s * 0.12;
            break;
        default:

            invalidInput = true;
            break;
    }
}
else
{
    switch (city)
    {
        case "Sofia":
            comission = s * 0.12;
            break;
        case "Varna":
            comission = s * 0.13;
            break;
        case "Plovdiv":
            comission = s * 0.145;
            break;
        default:

            invalidInput = true;
            break;
    }
}
if (invalidInput)
{
    Console.WriteLine("error");
}
else
{
    Console.WriteLine($"{comission:f2}");
}