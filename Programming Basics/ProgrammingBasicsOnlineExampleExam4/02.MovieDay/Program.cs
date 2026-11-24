int timeForFilming = int.Parse(Console.ReadLine());
int countOfScenes  = int.Parse(Console.ReadLine()); 
double durationOfOneEscenee = double.Parse(Console.ReadLine());

double timePreparation = timeForFilming * 0.15;
double finalTime = timePreparation + countOfScenes * durationOfOneEscenee;

if (finalTime <= timeForFilming)
{
    double diff = Math.Abs(finalTime - timeForFilming);
    Console.WriteLine($"You managed to finish the movie on time! You have {Math.Round(diff)} minutes left!");
}
else if (timeForFilming < finalTime)
{
    double diff = Math.Abs(finalTime - timeForFilming);
    Console.WriteLine($"Time is up! To complete the movie you need {Math.Round(diff)} minutes.");
}