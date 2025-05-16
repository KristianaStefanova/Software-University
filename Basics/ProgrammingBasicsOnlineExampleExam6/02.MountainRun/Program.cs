double recordInSeconds = double.Parse(Console.ReadLine());  
double distanceInMeters = double.Parse(Console.ReadLine()); 
double timeInSecondsFor1Min = double.Parse(Console.ReadLine()); 

double timeRunner = distanceInMeters * timeInSecondsFor1Min;
double slower = Math.Floor(distanceInMeters / 50);
double timeExtra = slower * 30;
double finalTimeRunner = timeRunner + timeExtra;

if (recordInSeconds <= finalTimeRunner)
{
    double diff = finalTimeRunner - recordInSeconds;
    Console.WriteLine($"No! He was {diff:F2} seconds slower.");
}
else
{
    Console.WriteLine($"Yes! The new record is {finalTimeRunner:F2} seconds.");
}