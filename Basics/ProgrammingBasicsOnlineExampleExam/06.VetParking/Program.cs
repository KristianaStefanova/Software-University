int countOfDays = int.Parse(Console.ReadLine());
int countOfHours = int.Parse(Console.ReadLine());

double totalPrice = 0;

for (int day = 1; day <= countOfDays; day++)
{
    double pricePerDay = 0;

    for (int hour = 1; hour <= countOfHours; hour++)
    {
        if (day % 2 == 0 && hour % 2 != 0)
        {
            pricePerDay += 2.50;
        }
        else if (day % 2 != 0 && hour % 2 == 0)
        {
            pricePerDay += 1.25;
        }
        else
        {
            pricePerDay += 1;
        }
    }

    Console.WriteLine($"Day: {day} - {pricePerDay:F2} leva");
    totalPrice += pricePerDay;
}

Console.WriteLine($"Total: {totalPrice:F2} leva");