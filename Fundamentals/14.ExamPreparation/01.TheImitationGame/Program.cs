using System.Collections.Generic;
using System.Runtime.CompilerServices;

class Program
{
    static void Main()
    {
        string encryptedMessage = Console.ReadLine();

        string input = String.Empty;

        while ((input = Console.ReadLine()) != "Decode")
        {
            string[] arguments = input.Split("|");

            string action = arguments[0];

            switch (action)
            {
                case "Move":
                    encryptedMessage = Move(int.Parse(arguments[1]), encryptedMessage);

                    break;
                case "Insert":
                    encryptedMessage = Insert(int.Parse(arguments[1]), arguments[2], encryptedMessage);

                    break;
                case "ChangeAll":
                    encryptedMessage = ChangeAll(arguments[1], arguments[2], encryptedMessage);

                    break;
            }
        }

        Console.WriteLine($"The decrypted message is: {encryptedMessage}");
    }

    static string ChangeAll(string substring, string replacement, string encryptedMessage)
    {
        if (encryptedMessage.Contains(substring))
        {
            encryptedMessage = encryptedMessage.Replace(substring, replacement);
        }

        return encryptedMessage;
    }

    static string Insert(int index, string value, string encryptedMessage)
    {
        encryptedMessage = encryptedMessage.Insert(index, value);

        return encryptedMessage;
    }

    static string Move(int count, string encryptedMessage)
    {
        string substring = encryptedMessage.Substring(0, count);

        encryptedMessage = encryptedMessage.Replace(substring, "");

        encryptedMessage += substring;

        return encryptedMessage;
    }
}

