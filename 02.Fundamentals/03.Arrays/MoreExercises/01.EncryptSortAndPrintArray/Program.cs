class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());

        int[] sums = new int[count];

        for (int i = 0; i < count; i++)
        {
            string name = Console.ReadLine();

            int sum = 0;

            char[] vowels = { 'A', 'a', 'E', 'e', 'I', 'i', 'O', 'o', 'U', 'u' };

            foreach (char symbol in name)
            {
                if (vowels.Contains(symbol))
                {
                    sum += symbol * name.Length;
                }
                else
                {
                    sum += symbol / name.Length;
                }
            }

            sums[i] = sum;
        }

        bool swappped = false;

        do
        {
            swappped = false;
            for (int i = 1; i < sums.Length; i++)
            {
                int leftNum = sums[i - 1];
                int rightNum = sums[i];

                if (leftNum > rightNum)
                {
                    sums[i - 1] = rightNum;
                    sums[i] = leftNum;
                    swappped = true;
                }
            }
        } while (swappped);
        Console.WriteLine(String.Join(Environment.NewLine, sums));









    }
}



