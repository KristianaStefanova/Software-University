namespace _06.EvenAndOddSubtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sumEvenNum = 0;
            int sumOddNum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    sumEvenNum += numbers[i];
                }
                else
                {
                    sumOddNum += numbers[i];
                }
            }

            int result = sumEvenNum - sumOddNum;

            Console.WriteLine(result);
        }
    }
}
