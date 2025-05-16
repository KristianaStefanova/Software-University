string round = Console.ReadLine();
string typeOfTicket = Console.ReadLine();

int countOfTickets = int.Parse(Console.ReadLine());
char photoExtra = char.Parse(Console.ReadLine());

double priceAllTickets = 0;

if (round == "Quarter final")
{
    switch (typeOfTicket)
    {
        case "Standard":
            priceAllTickets = 55.50 * countOfTickets;
            break;
        case "Premium":
            priceAllTickets = 105.20 * countOfTickets;
            break;
        case "VIP":
        default:
            priceAllTickets = 118.90 * countOfTickets;
            break;
    }
}

if (round == "Semi final")
{
    switch (typeOfTicket)
    {
        case "Standard":
            priceAllTickets = 75.88 * countOfTickets;
            break;
        case "Premium":
            priceAllTickets = 125.22 * countOfTickets;
            break;
        case "VIP":
        default:
            priceAllTickets = 300.40 * countOfTickets;
            break;
    }
}

if (round == "Final")
{
    switch (typeOfTicket)
    {
        case "Standard":
            priceAllTickets = 110.10 * countOfTickets;
            break;
        case "Premium":
            priceAllTickets = 160.66 * countOfTickets;
            break;
        case "VIP":
        default:
            priceAllTickets = 400 * countOfTickets;
            break;
    }
}

if (priceAllTickets > 4000)
{
    priceAllTickets *= 0.75;
    Console.WriteLine($"{ priceAllTickets:F2}");

}
else if (priceAllTickets > 2500)
{
   priceAllTickets *= 0.9;
    if (photoExtra == 'Y')
    {
        priceAllTickets += 40 * countOfTickets;
        Console.WriteLine($"{priceAllTickets:F2}");
    }
    else
    {
        Console.WriteLine($"{priceAllTickets:F2}");
    }
}
else if (priceAllTickets < 2500)
{
    if (photoExtra == 'Y')
    {
        priceAllTickets += 40 * countOfTickets;
        Console.WriteLine($"{priceAllTickets:F2}");
    }
    else if (photoExtra == 'N')
    {
        Console.WriteLine($"{priceAllTickets:F2}");
    }
}

