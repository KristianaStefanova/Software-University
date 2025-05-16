class Program
{
    static void Main(string[] args)
    {
        int maxNum = 0;
        int midNum = 0;
        int minNum = 0;
       
        int first = int.Parse(Console.ReadLine());
        int second = int.Parse(Console.ReadLine());
        int third = int.Parse(Console.ReadLine());

        if (first >= second && first >= third)
        {
            maxNum = first;
        }
        if (first <= second && first <= third)
        {
            minNum = first;
        }
        if ((first >= second && first <= third) || (first >= third && first <= second))
        {
            midNum = first;
        }

        if (second >= first && second >= third)
        {
            maxNum = second;
        }
        if (second <= first && second <= third)
        {
            minNum = second;
        }
        if ((second >= first && second <= third) || (second >= third && second <= first))
        {
            midNum = second;
        }

        if (third >= first && third >= second)
        {
            maxNum = third;
        }
        if (third <= first && third <= second)
        {
            minNum = third;
        }
        if ((third >= first && third <= second) || (third >= second && third <= first))
        {
            midNum = third;
        }

        Console.WriteLine($"{maxNum}");
        Console.WriteLine($"{midNum}");
        Console.WriteLine($"{minNum}");
    }
}

