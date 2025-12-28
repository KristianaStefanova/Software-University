class Program
{
    static void Main()
    {
        List<int> firstList = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        List<int> secondList = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        List<int> margingList = new(firstList.Count + secondList.Count);

        int shorterList = firstList.Count < secondList.Count
            ? firstList.Count
            : secondList.Count;

        for (int i = 0; i < shorterList; i++)
        {
            margingList.Add(firstList[i]);
            margingList.Add(secondList[i]);
        }

        List<int> restList = GetRest(firstList, secondList);
        margingList.AddRange(restList);

        Console.WriteLine(string.Join(" ", margingList));

    }

    private static List<int> GetRest(List<int> first, List<int> second)
    {
        List<int> restList = new List<int>();
        if (first.Count > second.Count)
        {
            for (int i = second.Count; i < first.Count; i++)
            {
                restList.Add(first[i]);
            }
        }
        else
        {
            for (int j = first.Count; j < second.Count; j++)
            {
                restList.Add(second[j]);
            }
        }

        return restList;
    }
}

