int freeDays = int.Parse(Console.ReadLine());

int workingDays = 365 - freeDays;

int minutesWorkingDays = workingDays * 63;
int minutesFreeDays = freeDays * 127;

int allTimeForPlayInMinutes = minutesFreeDays + minutesWorkingDays;

int hoursForPlay = allTimeForPlayInMinutes / 60;
int minutesForPlay = allTimeForPlayInMinutes % 60;

if (allTimeForPlayInMinutes > 30000)
{
    int moreTime = allTimeForPlayInMinutes - 30000;
    int hoursMore = moreTime / 60;
    int minutesMore = moreTime % 60;
    Console.WriteLine($"Tom will run away");
    Console.WriteLine($"{hoursMore} hours and {minutesMore} minutes more for play");
}
else
{
    int lessTime = 30000 - allTimeForPlayInMinutes;
    int hoursLess = lessTime / 60;
    int minutesLess = lessTime % 60;
    Console.WriteLine("Tom sleeps well");
    Console.WriteLine($"{hoursLess} hours and {minutesLess} minutes less for play");
}