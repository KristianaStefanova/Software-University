using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string places = Console.ReadLine();

        string pattern = @"([\=\/])(?<Name>[A-Z][A-Za-z]{2,})\1";

        List<string> destinations = new List<string>();

        MatchCollection matches = Regex.Matches(places, pattern);

        int totalPoints = 0;

        foreach (Match match in matches)
        {
            string currentMatch = match.Groups["Name"].Value;

            destinations.Add(currentMatch);

            int travelPoints = currentMatch.Length;

            totalPoints += travelPoints;
        }

        Console.WriteLine($"Destinations: {string.Join(", ",destinations)}");
        Console.WriteLine($"Travel Points: {totalPoints}");
    }
}

