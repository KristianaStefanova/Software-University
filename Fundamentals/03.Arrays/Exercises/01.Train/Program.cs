using System.Threading.Channels;

class Program
{
    static void Main()
    {
        int countOfVagons = int.Parse(Console.ReadLine());

        int[] peopleEachVagon = new int[countOfVagons];

        int sum = 0;
        for (int i = 0; i < countOfVagons; i++)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            peopleEachVagon[i] = countOfPeople;
            sum += peopleEachVagon[i];
        }

        Console.WriteLine(string.Join(' ',peopleEachVagon));
        Console.WriteLine(sum);
    }
}

