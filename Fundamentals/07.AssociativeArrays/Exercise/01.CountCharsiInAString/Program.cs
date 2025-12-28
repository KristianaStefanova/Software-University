namespace _01.CountCharsiInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> charOccurrences = new Dictionary<char, int>();

            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                var character = text[i];

                if (character == ' ')
                {
                    continue;
                }

                if (!charOccurrences.ContainsKey(character))
                {
                    charOccurrences.Add(character, 0);
                }

                charOccurrences[character]++;
            }

            foreach ((char character, int count) in charOccurrences)
            {
                Console.WriteLine($"{character} -> {count}");
            }
        }

    }
}
