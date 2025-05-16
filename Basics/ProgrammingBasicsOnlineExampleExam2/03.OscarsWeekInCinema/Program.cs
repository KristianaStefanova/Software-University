string nameOfMovie = Console.ReadLine();
string typeOfSpace = Console.ReadLine();
int countOfTickets = int.Parse(Console.ReadLine());

double moneyInput = 0;

if (typeOfSpace == "normal")
{
    switch (nameOfMovie)
    {
        case "A Star Is Born":
            moneyInput = countOfTickets * 7.50;
            break;
        case "Bohemian Rhapsody":
            moneyInput = countOfTickets * 7.35;
            break;
        case "Green Book":
            moneyInput = countOfTickets * 8.15;
            break;
        case "The Favourite":
        default:
            moneyInput = countOfTickets * 8.75;
            break;
    }
}
else if (typeOfSpace == "luxury")
{
    switch (nameOfMovie)
    {
        case "A Star Is Born":
            moneyInput = countOfTickets * 10.50;
            break;
        case "Bohemian Rhapsody ":
            moneyInput = countOfTickets * 9.45;
            break;
        case "Green Book":
            moneyInput = countOfTickets * 10.25;
            break;
        case "The Favourite":
        default:
            moneyInput = countOfTickets * 11.55;
            break;
    }
}

else if (typeOfSpace == "ultra luxury")
{
    switch (nameOfMovie)
    {
        case "A Star Is Born":
            moneyInput = countOfTickets * 13.50;
            break;
        case "Bohemian Rhapsody":
            moneyInput = countOfTickets * 12.75;
            break;
        case "Green Book":
            moneyInput = countOfTickets * 13.25;
            break;
        case "The Favourite":
        default:
            moneyInput = countOfTickets * 13.95;
            break;
    }
}

Console.WriteLine($"{nameOfMovie} -> {moneyInput:F2} lv.");


