class Program
{
    static void Main()
    {
        List<int> list = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        List<int> elements = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        int number = elements[0];
        int power = elements[1];

        while (list.Contains(number))
        {
            int index = list.IndexOf(number);

            int leftIndex = Math.Max(0, index - power);
            int rightIndex = Math.Min(list.Count - 1, index + power);

            int range = rightIndex - leftIndex + 1;

            list.RemoveRange(leftIndex, range);
        }
        int sum = 0;

        foreach (var n in list)
        {
            sum += n;
        }
        Console.WriteLine(sum);
    }
}

