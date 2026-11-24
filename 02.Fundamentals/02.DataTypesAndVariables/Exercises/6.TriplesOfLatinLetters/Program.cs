class Program
{
    static void Main()
    {
        int counter = int.Parse(Console.ReadLine());

        for (int i = 0; i < counter; i++)
        {
            for (int j = 0; j < counter; j++)
            {
                for(int k = 0; k < counter; k++)
                {
                    char firstChar = (char)('a' + i);
                    char secondChar = (char)('a' + j);
                    char thirdChar = (char)('a' + k);

                    Console.WriteLine($"{firstChar}{secondChar}{thirdChar}");
                }
            }
        }





    }

}

