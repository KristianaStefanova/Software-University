class Program
{
    static void Main()
    {
        /*
        string[] path = Console.ReadLine().Split("\\");
        string arguments = path[path.Length - 1];
        string[] nameAndExtension = arguments.Split(".");
        string name = nameAndExtension[0];
        string extension = nameAndExtension[1];

        Console.WriteLine($"File name: {name}");
        Console.WriteLine($"File extension: {extension}");
         */
        string path = Console.ReadLine();

        int indexName = path.LastIndexOf("\\");

        int indexExtension = path.LastIndexOf(".");
        string name = path.Substring(indexName + 1, indexExtension - indexName - 1);
        string extension = path.Substring(indexExtension + 1);

        Console.WriteLine($"File name: {name}");
        Console.WriteLine($"File extension: {extension}");
    }
}

