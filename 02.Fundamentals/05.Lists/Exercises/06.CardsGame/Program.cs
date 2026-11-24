class Program
{
    static void Main()
    {

        List<int> firstPlayerCardes = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        List<int> secondPlayerCardes = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        while (firstPlayerCardes.Count > 0 && secondPlayerCardes.Count > 0)
        {
            int cardFirst = firstPlayerCardes[0];
            int cardSecond = secondPlayerCardes[0];

            firstPlayerCardes.RemoveAt(0);
            secondPlayerCardes.RemoveAt(0);

            if (cardFirst > cardSecond)
            {
                firstPlayerCardes.Add(cardSecond);
                firstPlayerCardes.Add(cardFirst);
            }
            else if (cardFirst < cardSecond)
            {
                secondPlayerCardes.Add(cardFirst);
                secondPlayerCardes.Add(cardSecond);
            }
        }

        int pointsWinner = 0;

        if(firstPlayerCardes.Count != 0)
        {
            foreach (var p in firstPlayerCardes)
            {
                pointsWinner += p;

            }
            Console.WriteLine($"First player wins! Sum: {pointsWinner}");
        }
        else
        {
            foreach (var p in secondPlayerCardes)
            {
                pointsWinner += p;
            }
            Console.WriteLine($"Second player wins! Sum: {pointsWinner}");
        }
        
    }
}

