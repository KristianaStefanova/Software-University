int vaucher = int.Parse(Console.ReadLine());
int counterTicketMovie = 0;
int counterOther = 0;

while (true)
{
    string whatLuboBuy = Console.ReadLine();
    if (whatLuboBuy == "End")
    {
        Console.WriteLine(counterTicketMovie);
        Console.WriteLine(counterOther);
        break;
    }
    int lenght = whatLuboBuy.Length;

    if (lenght > 8)
    {
        int firstDigit = whatLuboBuy[0];
        int secondDigit = whatLuboBuy[1];
        int priceForTicket = firstDigit + secondDigit;
        if (vaucher >= priceForTicket)
        {
            counterTicketMovie++;
            vaucher -= priceForTicket;
        }
        else if (vaucher < priceForTicket)
        {
            Console.WriteLine(counterTicketMovie);
            Console.WriteLine(counterOther);
            break;
        }
    }
    else if (lenght <= 8)
    {
        int otherProducts = whatLuboBuy[0];
        if (vaucher >= otherProducts)
        {
            counterOther++;
            vaucher -= otherProducts;
        }
        else if (vaucher < otherProducts)
        {
            Console.WriteLine(counterTicketMovie);
            Console.WriteLine(counterOther);
            break;
        }
    }
}