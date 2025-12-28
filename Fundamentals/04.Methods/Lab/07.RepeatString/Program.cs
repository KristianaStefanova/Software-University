
class Program
{
    static void Main(string[] args)
    {
        string str = Console.ReadLine();
        int repetitions = int.Parse(Console.ReadLine());

        RepeatString(str, repetitions);
        Console.WriteLine(RepeatString(str, repetitions));
    }

    private static string RepeatString(string str, int repetitions)
    {
        string repeatedString = "";
        for (int i = 0; i < repetitions; i++)
        {
            repeatedString += str;
        }

        return repeatedString;
    }
}

