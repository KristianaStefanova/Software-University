using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main()
    {
        int counter = int.Parse(Console.ReadLine());

        List<string> guests = new List<string>();

        for (int i = 0; i < counter; i++)
        {
            string[] command = Console.ReadLine()
                .Split()
                .ToArray();

            string name = command[0];

            if (command[2] == "going!")
            {
                if (guests.Contains(name))
                {
                    Console.WriteLine($"{name} is already in the list!");
                }
                else
                {
                    guests.Add(name);
                }
            }
            else if (command[2] == "not")
            {
                if (guests.Contains(name))
                {
                    guests.Remove(name);

                }
                else
                {
                    Console.WriteLine($"{name} is not in the list!");
                }
            }
        }
        
        Console.WriteLine(string.Join("\n", guests));
    }
}

