int countOfBalls = int.Parse(Console.ReadLine());

int counterRed = 0;
int counterOrange = 0;
int counterYellow = 0;
int counterWhite = 0;
int counterOther = 0;
int dividedBlack = 0;
double finalPoints = 0;

for (int i = 0; i < countOfBalls; i++)
{
    string color = (Console.ReadLine());
    
    if  (color == "red")
    {
        finalPoints += 5;
        counterRed++;
    }
    else if(color == "orange")
    {
        finalPoints += 10;
        counterOrange++;
    }
    else if(color == "yellow")
    {
        finalPoints += 15;
        counterYellow++;
    }
    else if(color == "white")
    {
        finalPoints += 20;
        counterWhite++;
    }
    else if(color == "black")
    {
        finalPoints = Math.Floor(finalPoints / 2);
        dividedBlack++;
    }
    else
    {
        counterOther++;
    }
}

Console.WriteLine($"Total points: {finalPoints}");
Console.WriteLine($"Red balls: {counterRed}");
Console.WriteLine($"Orange balls: {counterOrange}");
Console.WriteLine($"Yellow balls: {counterYellow}");
Console.WriteLine($"White balls: {counterWhite}");
Console.WriteLine($"Other colors picked: {counterOther}");
Console.WriteLine($"Divides from black balls: {dividedBlack}");