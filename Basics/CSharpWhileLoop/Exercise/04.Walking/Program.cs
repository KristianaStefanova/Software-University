int goal = 10000;
int totalSteps = 0;
int stepsOver = 0;

while (totalSteps < goal)
{
    string input = Console.ReadLine();

    if (input == "Going home")
    {
        int stepsToReachHome = int.Parse(Console.ReadLine());
        totalSteps += stepsToReachHome;
        break;
    }

    int stepsPerDay = int.Parse(input);
    totalSteps += stepsPerDay;
}
   
if (totalSteps >= 10000)
{
    stepsOver = totalSteps - 10000;
    Console.WriteLine("Goal reached! Good job!");
    Console.WriteLine($"{stepsOver} steps over the goal!");
}
else
{
    int stepsToReachTheGoal = 10000 - totalSteps;
    Console.WriteLine($"{stepsToReachTheGoal} more steps to reach goal.");
}