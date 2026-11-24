class Program
{
    static void Main()
    {
        int countOfLines = int.Parse(Console.ReadLine());

        string[] firstArray = new string[countOfLines];
        string[] secondArray = new string[countOfLines];

        string[] numbers = new string[2];

        for (int i = 0; i < countOfLines; i++)
        {
            numbers = Console.ReadLine().Split();

            if (i % 2 == 0)
            {
                firstArray[i] = numbers[0];
                secondArray[i] = numbers[1];
            }
            else
            {
                secondArray[i] = numbers[0];
                firstArray[i] = numbers[1];
            }

        }

        Console.Write(string.Join(' ', firstArray));
        Console.WriteLine();
        Console.Write(string.Join(' ', secondArray));
    }
}

