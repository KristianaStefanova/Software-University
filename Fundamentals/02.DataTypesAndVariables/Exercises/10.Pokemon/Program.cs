

using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        int power = int.Parse(Console.ReadLine());
        int distance = int.Parse(Console.ReadLine());
        int exhaustionFactor = int.Parse(Console.ReadLine());
        int counterTargets = 0;
        double midPower = (double)power / 2;

        while (power >= distance)
        {
            power -= distance;
            counterTargets++;

            if (midPower == power && exhaustionFactor != 0)
            {
                power /= exhaustionFactor;
            }
        }

        Console.WriteLine(power);
        Console.WriteLine(counterTargets);
    }
}

