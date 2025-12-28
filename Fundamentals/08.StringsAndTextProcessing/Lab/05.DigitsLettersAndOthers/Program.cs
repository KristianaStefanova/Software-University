using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        StringBuilder digits = new StringBuilder();
        StringBuilder letters = new StringBuilder();
        StringBuilder symbols = new StringBuilder();

        foreach (char ch in input)
        {
            if (char.IsDigit(ch))
            {
                digits.Append(ch);
            }
            else if (char.IsLetter(ch))
            {
                letters.Append(ch);
            }
            else
            {
                symbols.Append(ch);
            }
        }

        Console.WriteLine(digits.ToString());
        Console.WriteLine(letters.ToString());
        Console.WriteLine(symbols.ToString());
    }
}

