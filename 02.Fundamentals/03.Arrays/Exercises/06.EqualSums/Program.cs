class Program
{
    static void Main()
    {
        int[] array = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int index = -1;

        for (int i = 0; i < array.Length; i++)
        {
            int leftSum = 0;
            int rightSum = 0;

            for (int j = i + 1; j < array.Length; j++)
            {
                rightSum += array[j];
            }

            for (int j = i - 1; j >= 0; j--)
            {
                leftSum += array[j];
            }

            if (leftSum == rightSum)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            Console.WriteLine("no");
        }
        else
        {
            Console.WriteLine(index);
        }
    }
}

