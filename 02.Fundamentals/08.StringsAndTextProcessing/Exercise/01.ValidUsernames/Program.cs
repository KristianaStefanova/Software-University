class Program
{
    static void Main()
    {
        string[] usernames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

        foreach (string username in usernames)
        {
            if (username.Length < 3 || username.Length > 16)
            {
                continue;
            }

            bool isValid = username.All(character =>
                char.IsLetterOrDigit(character) || character == '-' || character == '_');

            if (isValid)
            {
                Console.WriteLine(username);
            }
        }
    }
}

