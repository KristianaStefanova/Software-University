string nameCompany = Console.ReadLine();
int normalTickets = int.Parse(Console.ReadLine());
int ticketsKids = int.Parse(Console.ReadLine());    
double priceNormalTicket  = double.Parse(Console.ReadLine());
double priceServicing = double.Parse(Console.ReadLine());

double priceKidsTicket = priceNormalTicket * 0.30 + priceServicing;
double finalPriceNormalTicket = priceNormalTicket + priceServicing;

double totalPriceKids = ticketsKids * priceKidsTicket;
double totalPriceNormal = normalTickets * finalPriceNormalTicket;
 

double totalPrice = totalPriceKids + totalPriceNormal;

double profit = totalPrice * 0.2;

Console.WriteLine($"The profit of your agency from {nameCompany} tickets is {profit:F2} lv.");