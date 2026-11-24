class Program
{
    static void Main()
    {
        int days = int.Parse(Console.ReadLine());
        int countOfpeople = int.Parse(Console.ReadLine());
        double totalEnergy = double.Parse(Console.ReadLine());
        double neededWaterPerPerson = double.Parse(Console.ReadLine());
        double neededFoodPerPerson = double.Parse(Console.ReadLine());

        for (int i = 1; i <= days; i++)
        {
            double dailyEnergyLoss = double.Parse(Console.ReadLine());

            totalEnergy -= dailyEnergyLoss;
        }
    }
}

