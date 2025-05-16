using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        int countOfOrders = int.Parse(Console.ReadLine());
        double finalPrice = 0.0;
        double totalPrice = 0.0;
        for (int i = 0; i < countOfOrders; i++)
        {
            double pricePerCapsule = double.Parse(Console.ReadLine());  

            int days = int.Parse(Console.ReadLine());   

            int capsulesCount = int.Parse(Console.ReadLine());

            finalPrice = pricePerCapsule * days * capsulesCount;

            Console.WriteLine($"The price for the coffee is: ${finalPrice:F2}");

            totalPrice += finalPrice;
        }
        Console.WriteLine($"Total: ${totalPrice:F2}");
    }
}

