using System.Numerics;

class Program
{
    static void Main()
    {
        int countOfSnowballs = int.Parse(Console.ReadLine());

        BigInteger bestSnowball = 0;
        int bestSnowballSnow = 0;
        int bestSnowballTime = 0;
        int bestSnowballQuality = 0;
        

        for (int i = 0; i < countOfSnowballs; i++)
        {
            int snow = int.Parse(Console.ReadLine());
            int time = int.Parse(Console.ReadLine());
            int quality = int.Parse(Console.ReadLine());

           BigInteger result = BigInteger.Pow((snow / time), quality);
            if (result > bestSnowball)
            {
                bestSnowball = result;
                bestSnowballSnow = snow;
                bestSnowballTime = time;
                bestSnowballQuality = quality;
            }
        }

        Console.WriteLine($"{bestSnowballSnow} : {bestSnowballTime} = {bestSnowball} ({bestSnowballQuality})");
    }
}

