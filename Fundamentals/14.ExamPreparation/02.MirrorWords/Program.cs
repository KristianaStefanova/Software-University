using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        string pattern = @"([\@\#])(?<word1>[A-Za-z]{3,})\1\1(?<word2>[A-Za-z]{3,})\1";

        MatchCollection matches = Regex.Matches(input, pattern);

        List<string> mirrorWords = new List<string>();

        if (matches.Count == 0)
        {
            Console.WriteLine("No word pairs found!");
        }
        else
        {
            Console.WriteLine($"{matches.Count} word pairs found!");

            foreach (Match match in matches)
            {
                string firstWord = match.Groups["word1"].Value;
                string secondWord = match.Groups["word2"].Value;

                char[] word2Array = secondWord.ToCharArray();

                Array.Reverse(word2Array);

                string strWord2 = new string(word2Array);

                if (strWord2 == firstWord)
                {
                    mirrorWords.Add($"{firstWord} <=> {secondWord}");
                }
            }
        }

        if (mirrorWords.Count == 0)
        {
            Console.WriteLine("No mirror words!");
        }
        else
        {
            Console.WriteLine("The mirror words are:");
            Console.WriteLine(string.Join(", ", mirrorWords));
        }
    }
}

