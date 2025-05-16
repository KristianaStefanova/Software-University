string projection = Console.ReadLine();
string packetForFilm = Console.ReadLine();
int countOfTickets = int.Parse(Console.ReadLine());

double finalPrice = 0;

if (projection == "John Wick")
{
	switch (packetForFilm)
	{
		case "Drink":
            finalPrice = 12 * countOfTickets;
			break;
		case "Popcorn":
            finalPrice = 15 * countOfTickets;
			break;
		case "Menu":
            finalPrice = 19 * countOfTickets;
			break;
    }
}
else if (projection == "Star Wars")
{
	switch (packetForFilm)
	{
        case "Drink":
            finalPrice = 18 * countOfTickets;
            break;
        case "Popcorn":
            finalPrice = 25 * countOfTickets;
            break;
        case "Menu":
            finalPrice = 30 * countOfTickets;
            break;
    }
}
else if (projection == "Jumanji")
{
	switch (packetForFilm)
	{
        case "Drink":
            finalPrice = 9 * countOfTickets;
            break;
        case "Popcorn":
            finalPrice = 11 * countOfTickets;
            break;
        case "Menu":
            finalPrice = 14 * countOfTickets;
            break;
    }
}

if (projection == "Star Wars" && countOfTickets >= 4)
{
    finalPrice *= 0.7;
}
else if (projection == "Jumanji" && countOfTickets == 2)
{
    finalPrice *= 0.85;
}

Console.WriteLine($"Your bill is {finalPrice:F2} leva.");