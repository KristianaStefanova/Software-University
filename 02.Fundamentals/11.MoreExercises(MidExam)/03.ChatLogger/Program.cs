class Program
{
    static void Main()
    {
        List<string> chat = new List<string>();

        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            string[] arguments = command.Split();

            switch (arguments[0])
            {
                case "Chat":
                    Chat(chat, arguments[1]);
                    break;

                case "Delete":
                    Delete(chat, arguments[1]);
                    break;

                case "Edit":
                    Edit(chat, arguments[1], arguments[2]);
                    break;

                case "Pin":
                    Pin(chat, arguments[1]);
                    break;

                case "Spam":
                    List<string> messageSpam = arguments.ToList();

                    messageSpam.RemoveAt(0);
                    chat.AddRange(messageSpam);
                    break;
            }
        }

        Console.WriteLine(string.Join("\n", chat));
    }
    static void Pin(List<string> chat, string message)
    {
        if (chat.Contains(message))
        {
            chat.Remove(message);
            chat.Add(message);
        }
    }
    static void Edit(List<string> chat, string message, string editedVersion)
    {
        if (chat.Contains(message))
        {
            int index = chat.IndexOf(message);
            chat.Remove(message);
            chat.Insert(index, editedVersion);
        }
    }
    static void Delete(List<string> chat, string message)
    {
        if (chat.Contains(message))
        {
            chat.Remove(message);
        }
    }
    static void Chat(List<string> chat, string message)
    {
        chat.Add(message);
    }
}

