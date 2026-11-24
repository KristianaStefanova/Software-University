namespace _03.AlmostEqual2sComplement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double Float1 = double.Parse(Console.ReadLine());
            double Float2 = double.Parse(Console.ReadLine());
            bool areEquals = false;

            if (Math.Abs(Float1 - Float2) < 0.000001)
            {
                areEquals = true;
                Console.WriteLine(areEquals);
            }
            else
            {
                Console.WriteLine(areEquals);
            }

        }
    }
}
