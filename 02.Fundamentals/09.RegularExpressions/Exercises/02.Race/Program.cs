using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Dictionary<string, int> participantsMap = new Dictionary<string, int>();

        string[] participantsArray = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < participantsArray.Length; i++)
        {
            participantsMap.Add(participantsArray[i], 0);
        }

        string namePattern = @"[A-Za-z]+";
        string digitsPattern = @"\d";

        string input;
        while ((input = Console.ReadLine()) != "end of race")
        {
            StringBuilder name = new StringBuilder();
            foreach (Match match in Regex.Matches(input, namePattern))
            {
                name.Append(match);
            }

            int distance = 0;

            if (participantsMap.ContainsKey(name.ToString()))
            {
                foreach (Match match in Regex.Matches(input, digitsPattern))
                {
                    distance += int.Parse(match.Value);
                }
                participantsMap[name.ToString()] += distance;
            }
        }

        List<KeyValuePair<string, int>> orderedParticipants = participantsMap.OrderByDescending(pair => pair.Value).ToList();

        Console.WriteLine($"1st place: {orderedParticipants[0].Key}");
        Console.WriteLine($"2nd place: {orderedParticipants[1].Key}");
        Console.WriteLine($"3rd place: {orderedParticipants[2].Key}");
    }
}


