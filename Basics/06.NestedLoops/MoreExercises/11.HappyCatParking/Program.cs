int countOfDays = int.Parse(Console.ReadLine());    
int countOfHoursPerDay  = int.Parse(Console.ReadLine());

double totalPricePerDay = 0.0;
double totalPrice = 0.0;
for (int day = 1; day <= countOfDays; day++)
{
    for (int hour = 1; hour <= countOfHoursPerDay; hour++)
    {
        if (day % 2 == 0 && hour % 2 != 0)
        {
            totalPricePerDay += 2.5;
        }
        else if (day % 2 != 0 && hour % 2 == 0)
        {
            totalPricePerDay += 1.25;
        }
        else
        {
            totalPricePerDay += 1;
        }
    }
        Console.WriteLine($"Day: {day} - {totalPricePerDay:F2} leva");
        totalPrice += totalPricePerDay;
        totalPricePerDay = 0;
}
Console.WriteLine($"Total: {totalPrice:F2} leva");