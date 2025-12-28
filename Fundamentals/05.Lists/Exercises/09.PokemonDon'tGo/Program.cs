class Program
{
    static void Main()
    {
        List<int> sequence = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        int sumElements = 0;
        while (sequence.Count > 0)
        {
            bool invalidIndex = false;
            int copyRemovedNumber = 0;
            int indexPokemon = int.Parse(Console.ReadLine());

            if (indexPokemon < 0)
            {
                invalidIndex = true;
                indexPokemon = 0;
                copyRemovedNumber = sequence[indexPokemon];
                sumElements += copyRemovedNumber;
                sequence.RemoveAt(indexPokemon);
                sequence.Insert(indexPokemon, sequence[sequence.Count - 1]);
            }
            else if (indexPokemon > sequence.Count - 1)
            {
                invalidIndex = true;
                indexPokemon = sequence.Count - 1;
                copyRemovedNumber = sequence[indexPokemon];
                sumElements += copyRemovedNumber;
                sequence.RemoveAt(indexPokemon);
                sequence.Add(sequence[0]);
            }

            if (invalidIndex == false)
            {
                copyRemovedNumber = sequence[indexPokemon];
                sumElements += sequence[indexPokemon];
                sequence.RemoveAt(indexPokemon);
            }

            for (int i = 0; i < sequence.Count; i++)
            {

                if (sequence[i] <= copyRemovedNumber)
                {
                    sequence[i] += copyRemovedNumber;
                }
                else if (sequence[i] >= copyRemovedNumber)
                {
                    sequence[i] -= copyRemovedNumber;
                }
            }
        }

        Console.WriteLine(sumElements);
    }
}

