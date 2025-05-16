int numOfRounds = int.Parse(Console.ReadLine());

double totalPoints = 0.0;
int counterFrom40To50 = 0;
int counterFrom30To39 = 0;
int counterFrom20To29 = 0;
int counterFrom10To19 = 0;
int counterFrom0To9 = 0;
int counterInvalidNumber = 0;

for (int i = 1; i <= numOfRounds; i++)
{
    int number = int.Parse(Console.ReadLine());

    if (number < 0 || number > 50)
    {
        counterInvalidNumber++;
        totalPoints /= 2;
    }
    else if (number >= 40 && number <= 50)
    {
        totalPoints += 100;
        counterFrom40To50++;
    }
    else if (number >= 30 && number <= 39)
    {
        totalPoints += 50;
        counterFrom30To39++;
    }
    else if (number >= 20 && number <= 29)
    {
        totalPoints += number * 0.4;
        counterFrom20To29++;
    }
    else if (number >= 10 && number <= 19)
    {
        totalPoints += number * 0.3;
        counterFrom10To19++;
    }
    else if (number >= 0 && number <= 9)
    {
        totalPoints += number * 0.2;
        counterFrom0To9++;
    }
}
double percentFrom40To50 = (double)counterFrom40To50 / numOfRounds * 100;
double percentFrom30To39 = (double)counterFrom30To39 / numOfRounds * 100;
double percentFrom20To29 = (double)counterFrom20To29 / numOfRounds * 100;
double percentFrom10To19 = (double)counterFrom10To19 / numOfRounds * 100;
double percentFrom0To9 = (double)counterFrom0To9 / numOfRounds * 100;
double percentInvalidNumber = (double)counterInvalidNumber / numOfRounds * 100;

Console.WriteLine($"{totalPoints:F2}");
Console.WriteLine($"From 0 to 9: {percentFrom0To9:F2}% ");
Console.WriteLine($"From 10 to 19: {percentFrom10To19:F2}%");
Console.WriteLine($"From 20 to 29: {percentFrom20To29:F2}%");
Console.WriteLine($"From 30 to 39: {percentFrom30To39:F2}%");
Console.WriteLine($"From 40 to 50: {percentFrom40To50:F2}%");
Console.WriteLine($"Invalid numbers: {percentInvalidNumber:F2}%");