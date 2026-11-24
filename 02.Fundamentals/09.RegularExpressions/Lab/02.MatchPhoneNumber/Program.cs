using System.Security;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string pattern = @"\+359([\-\s])2\1\d{3}[\-\s]\d{4}\b";

        string phones = Console.ReadLine();

        MatchCollection phoneMatches = Regex.Matches(phones, pattern);

        string[] matchedPhones = phoneMatches
            .Cast<Match>()
            .Select(a=> a.Value.Trim())
            .ToArray();

        Console.WriteLine(string.Join(", ", matchedPhones));
    }
}

