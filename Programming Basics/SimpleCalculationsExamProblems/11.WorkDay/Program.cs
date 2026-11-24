int hoursProject = int.Parse(Console.ReadLine());
int daysLeft = int.Parse(Console.ReadLine());
int workersExtraHours = int.Parse(Console.ReadLine());

double workingDays = daysLeft * 0.9;
double workingHours = workingDays * 8;
double totalHoursExtra = workersExtraHours * workingDays *2;
double finalHours = totalHoursExtra + workingHours;


if (hoursProject <= finalHours)
{
   double diff = finalHours - hoursProject;
    Console.WriteLine($"Yes!{Math.Floor(diff)} hours left.");
}
else
{
    double neededLitters = hoursProject - finalHours;
    Console.WriteLine($"“Not enough time!{Math.Floor(neededLitters)} hours needed.");
}