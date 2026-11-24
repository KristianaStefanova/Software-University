using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        string validationPattern = @"(?<Surround>\:{2}|\*{2})(?<Emoji>[A-Z][a-z]{2,})\k<Surround>";
        string coolPattern = @"\d";

        MatchCollection numberMatches = Regex.Matches(input, coolPattern);
        MatchCollection emojiMatch = Regex.Matches(input, validationPattern);

        long value = 1;
        foreach (Match match in numberMatches)
        {
            value *= long.Parse(match.Value);
        }

        Console.WriteLine($"Cool threshold: {value}");
        Console.WriteLine($"{emojiMatch.Count} emojis found in the text. The cool ones are:");

        foreach (Match match in emojiMatch)
        {
            string emoji = match.Groups["Emoji"].Value;

            long threshold = emoji.ToCharArray().Sum(c => c);


            if (threshold >= value)
            {
                Console.WriteLine($"{match.Value}");
            }
        }
    }
}

