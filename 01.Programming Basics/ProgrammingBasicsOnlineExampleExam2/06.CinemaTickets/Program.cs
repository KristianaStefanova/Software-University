string nameMovie = Console.ReadLine();

int counterStudent = 0;
int counterStandard = 0;
int counterKid = 0;

while (nameMovie != "Finish")
{
    double percentSoldTickets = 0;
    int countCurrentMovie = 0;
    int freeSeats = int.Parse(Console.ReadLine());

    for (int i = 0; i < freeSeats; i++)
    {
        string typeOfTicket = Console.ReadLine();

        if (typeOfTicket == "End")
        {
            break;
        }
        if (typeOfTicket == "student")
        {
            counterStudent++;
            countCurrentMovie++;
        }
        else if (typeOfTicket == "standard")
        {
            counterStandard++;
            countCurrentMovie++;
        }
        else if (typeOfTicket == "kid")
        {
            counterKid++;
            countCurrentMovie++;
        }
    }

    percentSoldTickets = (double)countCurrentMovie / freeSeats * 100;
    Console.WriteLine($"{nameMovie} - {percentSoldTickets:F2}% full.");

    nameMovie = Console.ReadLine();
}
int totalTickets = counterKid + counterStudent + counterStandard;
Console.WriteLine($"Total tickets: {totalTickets}");

double percentStudent = (double)counterStudent / totalTickets * 100;
double percentStandard = (double)counterStandard / totalTickets * 100;
double percentKid = (double)counterKid / totalTickets * 100;

Console.WriteLine($"{percentStudent:F2}% student tickets.");
Console.WriteLine($"{percentStandard:F2}% standard tickets.");
Console.WriteLine($"{percentKid:F2}% kids tickets.");