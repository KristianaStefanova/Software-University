string projection = Console.ReadLine();
int countOfRow = int.Parse(Console.ReadLine());
int countOfColumn = int.Parse(Console.ReadLine());

double income = 0.0;

if (projection == "Premiere")
{
    income = countOfRow * countOfColumn * 12.00;
}
else if (projection == "Normal")
{
    income = countOfRow * countOfColumn * 7.50;
}
else if (projection == "Discount")
{
    income = countOfRow * countOfColumn * 5.0;
}
Console.WriteLine($"{income:f2} leva");


