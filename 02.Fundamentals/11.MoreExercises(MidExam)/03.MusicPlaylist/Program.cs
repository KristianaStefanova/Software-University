using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main()
    {
        List<string> list = Console.ReadLine()
            .Split()
            .ToList();

        int countOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfCommands; i++)
        {
            string[] command = Console.ReadLine()
                .Split(" * ")
                .ToArray();

            switch (command[0])
            {
                case "Add Song":
                    Add(list, command[1]);
                    break;

                case "Delete Song":
                    Delete(list, int.Parse(command[1]));
                    break;

                case "Shuffle Songs":
                    Shuffle(list, int.Parse(command[1]), int.Parse(command[2]));
                    break;

                case "Insert":
                    Insert(list, command[1], int.Parse(command[2]));
                    break;

                case "Sort":
                    Sort(list);
                    break;

                case "Play":
                    Play(list);
                    break;
            }
        }
    }
    private static void Play(List<string> list)
    {
        Console.WriteLine($"Songs to Play:\n{string.Join("\n", list)}");
    }

    private static void Sort(List<string> list)
    {
        list.Sort();
        list.Reverse();
    }

    private static void Insert(List<string> list, string song, int index)
    {
        if (index > 0 && index < list.Count)
        {
            if (list.Contains(song))
            {
                Console.WriteLine("Song is already in the playlist");
                return;
            }
            list.Insert(index, song);
            Console.WriteLine($"{song} successfully inserted");
        }
        else
        {
            Console.WriteLine("Index out of range");
        }
    }

    private static void Shuffle(List<string> list, int firstIndex, int secondIndex)
    {
        if (firstIndex > 0 && firstIndex < list.Count &&
            secondIndex > 0 && secondIndex < list.Count)
        {
            string copyFirstSong = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = copyFirstSong;
        }
        else
        {
            return;
        }

        Console.WriteLine($"{list[firstIndex]} is swapped with {list[secondIndex]}");
    }

    private static void Delete(List<string> list, int count)
    {
        if(count > list.Count)
        {
            return;
        }

        List<string> removedSongs = new (count);

        for (int i = 0; i < count; i++)
        {
            removedSongs.Add(list[i]);
        }

        list.RemoveRange(0, count);

        Console.WriteLine($"{string.Join(", ",removedSongs)} deleted");
    }
    
    private static void Add(List<string> list, string song)
    {
        list.Add(song);

        Console.WriteLine($"{song} successfully added");
    }
}

