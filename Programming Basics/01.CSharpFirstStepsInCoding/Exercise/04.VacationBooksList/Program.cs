int countOfPages = int.Parse(Console.ReadLine());
int readPagesPerHours = int.Parse(Console.ReadLine());
int countOfDays = int.Parse(Console.ReadLine());

int allHoursForRead = countOfPages / readPagesPerHours;
int hoursPerDay = allHoursForRead / countOfDays;

Console.WriteLine(hoursPerDay);

