int numOfPeople = int.Parse(Console.ReadLine());

int finalPrice = 0;
int ticketBill = 0;
int seatsLeft = 0;

int allPeople = 0;

while (true)
{
    string text = Console.ReadLine();
    if (text == "Movie time!")
    {
        Console.WriteLine($"There are {seatsLeft} seats left in the cinema.");
        Console.WriteLine($"Cinema income - {finalPrice} lv.");
        break;
    }

    int tickets = int.Parse(text);
    allPeople += tickets;
    ticketBill = tickets * 5;

    if (tickets % 3 == 0)
    {
        ticketBill -= 5;
    }

    if (allPeople > numOfPeople)
    {
        Console.WriteLine("The cinema is full.");
        Console.WriteLine($"Cinema income - {finalPrice} lv.");
        break;
    }

    finalPrice += ticketBill;
    seatsLeft = numOfPeople - allPeople;
}

