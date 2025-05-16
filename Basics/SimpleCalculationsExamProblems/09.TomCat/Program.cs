using System.Security.Cryptography;

int freeDays = int.Parse(Console.ReadLine());

int workDays = 365 - freeDays;
int minutesWorkDaysPerYear = workDays * 63;
int minutesFreeDays = freeDays * 127;
int finalMinutes = minutesWorkDaysPerYear + minutesFreeDays;

if (finalMinutes > 30000)
{
    int diff = finalMinutes - 30000;
    int hours = diff / 60;
    int minutes = diff % 60;
    Console.WriteLine("Tom will run away");
    Console.WriteLine($"{hours} hours and {minutes} minutes more for play");
}
else
{
    int diff = Math.Abs(finalMinutes - 30000);
    int minutes = diff % 60;
    int hours = diff / 60;

    Console.WriteLine($"Tom sleeps well {hours} hours and {minutes} minutes less for play");
}