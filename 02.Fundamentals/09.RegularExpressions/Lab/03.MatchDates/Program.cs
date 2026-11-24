using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string pattern = @"\b(?<Day>[0-9][0-9])(?<Separator>[\.\-\/])(?<Month>[A-Z][a-z]{2})\2(?<Year>\d{4})";

        string input = Console.ReadLine();

        foreach (Match date in Regex.Matches(input, pattern))
        {
            string day = date.Groups["Day"].Value;
            string month = date.Groups["Month"].Value;
            string year = date.Groups["Year"].Value;

            Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
        }
    }
}

