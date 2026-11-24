string nameMoovie = Console.ReadLine();
int countOfDays = int.Parse(Console.ReadLine());
int countOfTickets = int.Parse(Console.ReadLine());
double priceOneTicket = double.Parse(Console.ReadLine());
int percentCinema = int.Parse(Console.ReadLine());

double finalIncome = countOfDays * countOfTickets * priceOneTicket;
double cinemaIncome = finalIncome * (double)percentCinema / 100;
double incomeStudio = finalIncome - cinemaIncome;

Console.WriteLine($"The profit from the movie {nameMoovie} is {incomeStudio:F2} lv.");