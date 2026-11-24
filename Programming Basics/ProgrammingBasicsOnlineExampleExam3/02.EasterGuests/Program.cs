int numGuests = int.Parse(Console.ReadLine());
int budget = int.Parse(Console.ReadLine());

//Calculation

double breadNeeded = (double)numGuests / 3;
int numOfEggs = numGuests * 2;
double priceForEggs = numOfEggs * 0.45;
double priceBreadNeeded = Math.Ceiling(breadNeeded) * 4;

double totalMoneyNeeded = priceForEggs + priceBreadNeeded;

double diff = Math.Abs(totalMoneyNeeded - budget);
//Output
if (totalMoneyNeeded <= budget)
{
    Console.WriteLine($"Lyubo bought {Math.Ceiling(breadNeeded)} Easter bread and {numOfEggs} eggs.");
    Console.WriteLine($"He has {diff:F2} lv. left.");
}
else 
{
    Console.WriteLine($"Lyubo doesn't have enough money.");
    Console.WriteLine($"He needs {diff:F2} lv. more.");
}