using System.ComponentModel;

class Program
{
    static void Main()
    {
        Dictionary<string, List<string>> piecesMap = new Dictionary<string, List<string>>();

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string[] pieces = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

            string piece = pieces[0];
            string composer = pieces[1];
            string key = pieces[2];

            piecesMap.Add(piece, new List<string>(){composer, key});
        }

        string command;

        while ((command = Console.ReadLine()) != "Stop")
        {
            string[] arguments = command.Split("|", StringSplitOptions.RemoveEmptyEntries);

            string action = arguments[0];

            switch (action)
            {
                case "Add":
                    piecesMap = Add(arguments[1], arguments[2], arguments[3], piecesMap);
                    break;
                case "Remove":
                    piecesMap = Remove(arguments[1], piecesMap);
                    break;
                case "ChangeKey":
                    piecesMap = ChangeKey(arguments[1], arguments[2], piecesMap);
                    break;
            }
        }

        foreach (KeyValuePair<string, List<string>> piece in piecesMap)
        {
            Console.WriteLine($"{piece.Key} -> Composer: {piece.Value[0]}, Key: {piece.Value[1]}");
        }
    }
    static Dictionary<string, List<string>> ChangeKey(string piece, string newKey, Dictionary<string, List<string>> piecesMap)
    {
        if (!piecesMap.ContainsKey(piece))
        {
            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");

            return piecesMap;
        }

        piecesMap[piece][1] = newKey;
        Console.WriteLine($"Changed the key of {piece} to {newKey}!");

        return piecesMap;
    }
    static Dictionary<string, List<string>> Remove(string piece, Dictionary<string, List<string>> piecesMap)
    {
        if (!piecesMap.ContainsKey(piece))
        {
            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");

            return piecesMap;
        }

        piecesMap.Remove(piece);
        Console.WriteLine($"Successfully removed {piece}!");

        return piecesMap;
    }

    static Dictionary<string, List<string>> Add(string piece, string composer, string key, Dictionary<string, List<string>> piecesMap)
    {
        if (piecesMap.ContainsKey(piece))
        {
            Console.WriteLine($"{piece} is already in the collection!");

            return piecesMap;
        }

        piecesMap.Add(piece, new List<string>(){composer, key});
        
        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");

        return piecesMap;
    }
}

