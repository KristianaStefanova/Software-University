using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        List<Furniture> list = new List<Furniture>();
        string pattern = @">>(?<Name>[A-Za-z]+)<<(?<Price>(\d+\.?)\d+)\!(?<Quantity>\d+)";

        string input;
        while ((input = Console.ReadLine()) != "Purchase")
        {
            foreach (Match match in Regex.Matches(input, pattern))
            {
                Furniture newFurniture = new Furniture(
                    match.Groups["Name"].Value,
                    decimal.Parse(match.Groups["Price"].Value),
                    int.Parse(match.Groups["Quantity"].Value));

                list.Add(newFurniture);
            }
        }

        Console.WriteLine("Bought furniture:");

        decimal totalPrice = 0;
        foreach (Furniture furniture in list)
        {
            Console.WriteLine(furniture.Name);
            totalPrice += furniture.Price * furniture.Quantity;
        }

        Console.WriteLine($"Total money spend: {totalPrice:F2}");
    }

    class Furniture
    {
        public Furniture(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public decimal TotalPrice
        {
            get { return Price * (decimal)Quantity; }
        }
    }
}

