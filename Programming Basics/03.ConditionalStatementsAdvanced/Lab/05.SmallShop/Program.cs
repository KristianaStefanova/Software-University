
string product = Console.ReadLine();
string city = Console.ReadLine();
double count = double.Parse(Console.ReadLine());

double price = 0;
switch (product)
{
    case "coffee":
        switch (city)
        {
            case "Sofia":
                price = count * 0.50;
                break;
            case "Plovdiv":
                price = count * 0.40;
                break;
            case "Varna":
                price = count * 0.45;
                break;
        }
        break;
    case "water":
        switch (city)
        {
            case "Sofia":
                price = count * 0.80;
                break;
            case "Plovdiv":
            case "Varna":
                price = count * 0.70;
                break;
        }
        break;
    case "beer":
        switch (city)
        {
            case "Sofia":
                price = count * 1.20;
                break;
            case "Plovdiv":
                price = count * 1.15;
                break;
            case "Varna":
                price = count * 1.10;
                break;
        }
        break;
    case "sweets":
        switch (city)
        {
            case "Sofia":
                price = count * 1.45;
                break;
            case "Plovdiv":
                price = count * 1.30;
                break;
            case "Varna":
                price = count * 1.35;
                break;
        }
        break;
    case "peanuts":
        switch (city)
        {
            case "Sofia":
                price = count * 1.6;
                break;
            case "Plovdiv":
                price = count * 1.50;
                break;
            case "Varna":
                price = count * 1.55;
                break;
        }
        break;
}
Console.WriteLine(price);