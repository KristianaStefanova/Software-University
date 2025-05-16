using System.Diagnostics.Metrics;

int hourOfExam = int.Parse(Console.ReadLine());
int minutesOfExam = int.Parse(Console.ReadLine());
int hourArrival = int.Parse(Console.ReadLine());
int minutesArrival = int.Parse(Console.ReadLine());

int hoursExamInMinutes = hourOfExam * 60 + minutesOfExam;
int hoursArrivalInMinutes = hourArrival * 60 + minutesArrival;

if (hoursExamInMinutes < hoursArrivalInMinutes)
{
    Console.WriteLine("Late");

    int minutesLate = hoursArrivalInMinutes - hoursExamInMinutes;

    if (minutesLate < 60)
    {
        Console.WriteLine($"{minutesLate} minutes after the start");
    }
    else
    {
        int hours = minutesLate / 60;
        int minutes = minutesLate % 60;
        Console.WriteLine($"{hours}:{minutes:D2} hours after the start");
    }
}
else if (hoursExamInMinutes - hoursArrivalInMinutes <= 30)
{
    Console.WriteLine("On time");

    int minutesEarly = hoursExamInMinutes - hoursArrivalInMinutes;

    if (minutesEarly != 0)
    {
        Console.WriteLine($"{minutesEarly} minutes before the start");
    }
}
else
{
    Console.WriteLine("Early");

    int minutesEarly = hoursExamInMinutes - hoursArrivalInMinutes;

    if (minutesEarly < 60)
    {
        Console.WriteLine($"{minutesEarly} minutes before the start");
    }
    else
    {
        int hour = minutesEarly / 60;
        int minutes = minutesEarly % 60;

        Console.WriteLine($"{hour}:{minutes:D2} hours before the start");
    }
}