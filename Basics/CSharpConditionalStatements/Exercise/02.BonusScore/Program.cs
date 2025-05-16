//Input
int number = int.Parse(Console.ReadLine());
double bonusPoints = 0.0;

//Calculations 
if (number <= 100)
{
    bonusPoints = 5;

}
else if (number > 1000)
{
    bonusPoints = number * 0.1;
}
else if (number > 100)
{
    bonusPoints = number * 0.2;
}

if (number % 2 == 0)
{
    bonusPoints = bonusPoints + 1;
}
else if (number % 10 == 5)
{
    bonusPoints = bonusPoints + 2;
}

Console.WriteLine(bonusPoints);
Console.WriteLine(number + bonusPoints);



