string nameMovie = Console.ReadLine();
int countOfDays = int.Parse(Console.ReadLine());    
int countOfTickets = int.Parse(Console.ReadLine());
double priceOfTickets  = double.Parse(Console.ReadLine());
int percentCinema = int.Parse(Console.ReadLine());

double finalPriceStudio = countOfDays * countOfTickets * priceOfTickets;
double priceForCinema = finalPriceStudio * percentCinema / 100;
double finalPrice = finalPriceStudio - priceForCinema;

Console.WriteLine($"The profit from the movie {nameMovie} is {finalPrice:F2} lv.");
