using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        List<Message> messages = new List<Message>();

        int countOfMessages = int.Parse(Console.ReadLine());

        string msgPattern = @"@(?<Name>[A-Za-z]+)[^\@\-\!\,\:]*:(?<Population>\d+)[^\@\-\!\,\:]*\!(?<AttackType>[AD])\![^\@\-\!\,\:]*->(?<SoldierCount>\d+)";
        string decryptPattern = @"[SsTtAaRr]";

        for (int i = 0; i < countOfMessages; i++)
        {
            string encryptedMsg = Console.ReadLine();

            int decryptedKey = Regex.Matches(encryptedMsg, decryptPattern).Count;

            StringBuilder decryptedMessage = new StringBuilder();

            for (int j = 0; j < encryptedMsg.Length; j++)
            {
                char currentChar = (char)(encryptedMsg[j] - decryptedKey);

                decryptedMessage.Append(currentChar);
            }

            foreach (Match match in Regex.Matches(decryptedMessage.ToString(), msgPattern))
            {
                if (Regex.IsMatch(decryptedMessage.ToString(), msgPattern) == false)
                {
                    continue;
                }

                Message newMessage = new Message(
                    match.Groups["Name"].Value,
                    int.Parse(match.Groups["Population"].Value),
                    match.Groups["AttackType"].Value,
                    int.Parse(match.Groups["SoldierCount"].Value));

                messages.Add(newMessage);
            }
        }

        var planets = messages
            .Where(c => c.AttackType == "A")
            .OrderBy(m => m.Name)
            .ToList();

        Console.WriteLine($"Attacked planets: {planets.Count}");
        planets.ForEach(m=> Console.WriteLine($"-> {m.Name}"));

        planets = messages.Where(c => c.AttackType == "D").OrderBy(m => m.Name).ToList();
        Console.WriteLine($"Destroyed planets: {planets.Count}");
        planets.ForEach(m => Console.WriteLine($"-> {m.Name}"));
    }

    class Message
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public string AttackType { get; set; }
        public int SoldierCount { get; set; }

        public Message(string name, int population, string attackType, int soldierCount)
        {
            Name = name;
            Population = population;
            AttackType = attackType;
            SoldierCount = soldierCount;
        }
    }
}

