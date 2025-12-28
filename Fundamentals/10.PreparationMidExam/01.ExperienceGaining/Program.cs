class Program
{
    static void Main()
    {
        double neededExperience = double.Parse(Console.ReadLine());
        int amountOfBattles = int.Parse(Console.ReadLine());

        int battleCount = 0;
        double totalExperience = 0.0;
        bool isStopped = false;

        for (int i = 1; i <= amountOfBattles; i++)
        {
            double experiencePerBattle = double.Parse(Console.ReadLine());
            bool isChanged = false;
            battleCount++;

            if (i % 3 == 0)
            {
                totalExperience += experiencePerBattle * 1.15;
                isChanged = true;
            }

            if (i % 5 == 0)
            {
                totalExperience += experiencePerBattle * 0.90;
                isChanged = true;
            }

            if (i % 15 == 0)
            {
                totalExperience += experiencePerBattle * 1.05;
                isChanged = true;
            }

            if (!isChanged)
            {
                totalExperience += experiencePerBattle;
            }

            if (totalExperience >= neededExperience)
            {
                isStopped = true;
                break;
            }
        }

        if (isStopped || totalExperience >= neededExperience)
        {
            Console.WriteLine($"Player successfully collected his needed experience for {battleCount} battles.");
        }
        else
        {
            double neededExperienceMore = neededExperience - totalExperience;

            Console.WriteLine($"Player was not able to collect the needed experience, {neededExperienceMore:F2} more needed.");
        }
    }
}

