using System.Numerics;

class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        BigInteger[] nums = new BigInteger[number];
        nums[0] = 1;

        TribonacciSequence(nums, number);


        static void TribonacciSequence(BigInteger[] array, int number)
        {
            for (int i = 1; i < number; i++)
            {
                BigInteger sum = 0;
                for (int prev = i - 3; prev <= i - 1; prev++)
                {
                    if (prev >= 0)
                    {
                        sum += array[prev];
                    }

                    array[i] = sum;
                }
            }

            for (int i = 0; i < number; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}

