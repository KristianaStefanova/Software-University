class Program
{
    static void Main()
    {
        int centuries = int.Parse(Console.ReadLine());
        int yearsInOneCentuarie = 100;
        double daysInOneyear = 365.2422;
        int hoursPerDay = 24;
        int minutesInOneHour = 60;

        int yearsCenturies = yearsInOneCentuarie * centuries;
        int daysCenturies = (int)(daysInOneyear * yearsCenturies);
        long hoursCenturies = daysCenturies * hoursPerDay;
        long minutesCentuarie = (long)(hoursCenturies * minutesInOneHour);

        Console.WriteLine($"{centuries} centuries = {yearsCenturies} years = {daysCenturies} days = {hoursCenturies} hours = {minutesCentuarie} minutes");


    }
}

