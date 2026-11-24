double worldRecord = double.Parse(Console.ReadLine());
double distance = double.Parse(Console.ReadLine());
double timeToSwimOneMeter = double.Parse(Console.ReadLine());

//Calculation
double timeToSwim = distance * timeToSwimOneMeter;
double waterResist = Math.Floor(distance / 15) * 12.5;
double allTimeToSwim = timeToSwim + waterResist;


if (allTimeToSwim < worldRecord)
{
    Console.WriteLine($" Yes, he succeeded! The new world record is {allTimeToSwim:F2} seconds.");
}
else
{
    double secondsNeeded = allTimeToSwim - worldRecord;
    Console.WriteLine($"No, he failed! He was {secondsNeeded:F2} seconds slower.");
}