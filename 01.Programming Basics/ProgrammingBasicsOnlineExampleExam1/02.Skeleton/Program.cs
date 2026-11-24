int controlMinutes = int.Parse(Console.ReadLine());
int controlSeconds = int.Parse(Console.ReadLine());
double uleiLenght = double.Parse(Console.ReadLine());
int seconds100meters = int.Parse(Console.ReadLine());

double reduccionInSeconds = (uleiLenght /120) * 2.5;
double martinsTime = (uleiLenght / 100) * seconds100meters - reduccionInSeconds;
double totalInSeconds = controlMinutes * 60 + controlSeconds;

if (totalInSeconds < martinsTime)
{
    double secondsNeeded = martinsTime - totalInSeconds;
    Console.WriteLine($"No, Marin failed! He was {secondsNeeded:F3} second slower.");
}
else if (totalInSeconds >= martinsTime)
{
    Console.WriteLine($"Marin Bangiev won an Olympic quota!");
    Console.WriteLine($"His time is {martinsTime:F3}.");
}