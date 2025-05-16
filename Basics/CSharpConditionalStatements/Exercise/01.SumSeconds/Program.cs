//Input
int firstAthlete = int.Parse(Console.ReadLine());
int secondAthlete = int.Parse(Console.ReadLine());
int thirdAthlete = int.Parse(Console.ReadLine());

//Calculations 
int totalSeconds = firstAthlete + secondAthlete + thirdAthlete;
int minutes = totalSeconds / 60;
int seconds = totalSeconds % 60;

if (seconds < 10)
{
    Console.WriteLine($"{minutes}:0{seconds}");
}
else
{
    Console.WriteLine($"{minutes}:{seconds}");
}
