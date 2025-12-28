using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string text = Console.ReadLine();

        string pattern = @"(?<Surrounder>[\|\#])(?<Name>[A-Za-z ]+)\k<Surrounder>(?<Data>[0-9]{2}\/[0-9]{2}\/[0-9]{2})\k<Surrounder>(?<Calories>[\d]+)\k<Surrounder>";

        int dailyCalories = 2000;

        MatchCollection matches = Regex.Matches(text, pattern);

        int totalCalories = 0;

        foreach (Match match in matches)
        {
            int currentMatch = int.Parse(match.Groups["Calories"].Value);

            totalCalories += currentMatch;
        }

        int daysLeft = totalCalories / dailyCalories;

        Console.WriteLine($"You have food to last you for: {daysLeft} days!");

        foreach (Match match in matches)
        {
            Console.WriteLine($"Item: {match.Groups["Name"].Value}, Best before: {match.Groups["Data"].Value}, Nutrition: {match.Groups["Calories"].Value}");
        }
    }
}

