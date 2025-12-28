class Program
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());

        int[] numbers = new int[length];

        for (int i = 0; i < length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        for (int i = numbers.Length - 1; i >= 0; i--)
        {
            Console.Write(numbers[i] + " ");
        }
    }
}

