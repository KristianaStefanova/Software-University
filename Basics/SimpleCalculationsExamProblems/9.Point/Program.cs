using System.Security.Cryptography;

int hourExam = int.Parse(Console.ReadLine());
int minutesExam = int.Parse(Console.ReadLine());
int arrivalHour = int.Parse(Console.ReadLine());
int arrivalMinutes = int.Parse(Console.ReadLine());

int hourExamInMinutes = hourExam * 60 + minutesExam;
int hourArrivalInMinutes = arrivalHour * 60 + arrivalMinutes;

if (hourExamInMinutes < hourArrivalInMinutes)
{
    Console.WriteLine("Late");

   int minutesLate = hourArrivalInMinutes - hourExamInMinutes;
    if (minutesLate < 60)
    {
        Console.WriteLine($"{minutesLate} minutes after the start");
    }
    else if (minutesLate > 60)
    {
        int hours = minutesLate / 60;
        int minutes = minutesLate % 60;
        Console.WriteLine($"{hours}:{minutes:D2} hours after the start");
    }

}
else if (hourExamInMinutes - hourArrivalInMinutes > 30)
{
    int diff = hourExamInMinutes - hourArrivalInMinutes;

    Console.WriteLine($"Early");

    if (diff > 60)
    {
        int hours = diff / 60;
        int minutes = diff % 60;
        Console.WriteLine($"{hours}:{minutes:D2} hours before the start");
    }
    else if (diff < 60)
    {
        Console.WriteLine($"{diff} minutes before the start");
    }
}
else
{
    Console.WriteLine($"On time");
    int minutesEarly = hourExamInMinutes - hourArrivalInMinutes;

    if (minutesEarly != 0)
    {
        Console.WriteLine($"{minutesEarly} minutes before the start");
    }
}



