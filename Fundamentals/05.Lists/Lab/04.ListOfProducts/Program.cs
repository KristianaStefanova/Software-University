class Program
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());

        List<string> products = new(count);

        for (int i = 0; i < count; i++)
        {
            string procuct = Console.ReadLine();
            products.Add(procuct);
        }
        products.Sort();

        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i + 1}.{products[i]}");
        }
    }
}

