using System;

class Program
{
    static void Main()
    {
        Dictionary<string, string> contests = new Dictionary<string, string>();
        Dictionary<string, Dictionary<string, int>> ranking = new Dictionary<string, Dictionary<string, int>>();

        string command;
        string contest;
        string password;

        while ((command = Console.ReadLine()) != "end of contests")
        {
            string[] arguments = command.Split(":");
            contest = arguments[0];
            password = arguments[1];

            if (!contests.ContainsKey(contest))
            {
                contests.Add(contest, password);
            }
            else
            {
                contests[contest] = password;
            }
        }

        command = null;
        while ((command = Console.ReadLine()) != "end of submissions")
        {
            string[] arguments = command.Split("=>");
            contest = arguments[0];
            password = arguments[1];
            string username = arguments[2];
            int points = int.Parse(arguments[3]);


            if (contests.ContainsKey(contest) && contests[contest] == password)
            {
                if (!ranking.ContainsKey(username))
                {
                    ranking.Add(username, new Dictionary<string, int>());
                    ranking[username].Add(contest, points);
                }
                else
                {
                    if (!ranking[username].ContainsKey(contest))
                    {
                        ranking[username].Add(contest, points);
                    }
                    else if (ranking[username][contest] <= points)
                    {
                        ranking[username][contest] = points;
                    }
                }
            }

            var bestCandidate = ranking
                .Select(c => new KeyValuePair<string, int>(c.Key, c.Value.Values.Sum()))
                .OrderByDescending(c => c.Value)
                .First();

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value} points.");
            Console.WriteLine("Ranking: ");

            foreach (var candidate in ranking.OrderBy(c => c.Key))
            {
                Console.WriteLine($"{candidate.Key}");
                foreach (var course in candidate.Value.OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"#  {course.Key} -> {course.Value}");
                }
            }
        }
    }
}



