
class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        string middle = GetMidCharecter(input);

        Console.WriteLine(middle);
    }

    static string GetMidCharecter(string input)
    {
        string middle = "";

        if (input.Length % 2 == 0)
        {
            middle += input[input.Length / 2 - 1];
            middle += input[input.Length / 2];
        }
        else
        {
            middle += input[input.Length / 2];
        }

        return middle;
    }
}

