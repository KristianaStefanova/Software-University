namespace _01.GuineaPig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double food = double.Parse(Console.ReadLine()) * 1000;
            double hay = double.Parse(Console.ReadLine()) * 1000;
            double cover = double.Parse(Console.ReadLine()) * 1000;
            double weight = double.Parse(Console.ReadLine()) * 1000;

            double daysOFMonth = 30;
            double counterDays = 0;
            double percentHay = 0.05;

            while (food > 0 && hay > 0 && cover > 0)
            {
                counterDays++;

                if (counterDays > 30)
                {
                    break;
                }

                food -= 300;

                if (counterDays % 2 == 0)
                {
                    hay -= food * percentHay;
                }

                if (counterDays % 3 == 0)
                {
                    cover -= weight / 3;
                }
            }

            if (food > 0 && hay > 0 && cover > 0)
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {food / 1000:F2}, Hay: {hay / 1000:F2}, Cover: {cover / 1000:F2}.");
            }
            else
            {
                Console.WriteLine("Merry must go to the pet store!");
            }
        }
    }
}
