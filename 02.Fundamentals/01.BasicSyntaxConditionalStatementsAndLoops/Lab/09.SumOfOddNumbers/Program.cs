namespace _09.SumOfOddNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= n; i++)
            {
                int m = 2 * i - 1;
                Console.WriteLine(m);

                sum += m;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
