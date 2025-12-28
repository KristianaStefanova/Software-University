

class Program
{
    static void Main(string[] args)
    {
        string product = Console.ReadLine();
        double quantity = double.Parse(Console.ReadLine());

        CalculateAndPrintTotalProducts(product, quantity);
    }

    static void CalculateAndPrintTotalProducts(string procuct, double quantity)
    {
        double totalPrice = 0;
        switch (procuct)
        {
            case "coffee":
                totalPrice = 1.50 * quantity;
                break;
            case "water":
                totalPrice = 1 * quantity;
                break;
            case "coke":
                totalPrice = 1.40 * quantity;
                break;
            case "snacks":
                totalPrice = 2 * quantity;
                break;
        }

        Console.WriteLine($"{totalPrice:F2}");
    }
}


