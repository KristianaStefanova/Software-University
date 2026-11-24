class Program
{
    static void Main()
    {
        int[] array = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        while (array.Length > 1)
        {
            int[] condencedArray = new int[array.Length - 1];

            for (int i = 0; i < array.Length - 1; i++)
            {
                condencedArray[i] = array[i] + array[i + 1];
            }
            array = condencedArray;

        }

        Console.WriteLine(array[0]);
    }
}

