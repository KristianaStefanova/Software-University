string nameOfTVSerie = Console.ReadLine();
int countOfSeasons = int.Parse(Console.ReadLine());
int countOfEpisodes = int.Parse(Console.ReadLine());    
double durationInMitutes = double.Parse(Console.ReadLine());

double advertisingMinutes = durationInMitutes * 0.2;
double minutesExtra = countOfSeasons * 10;
double totalDurationWithAdv = durationInMitutes + advertisingMinutes;
double finalTime = countOfEpisodes * totalDurationWithAdv * countOfSeasons + minutesExtra;

Console.WriteLine($"Total time needed to watch the {nameOfTVSerie} series is {finalTime} minutes.");