using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>();

        string pattern = @"\%(?<Customer>[A-Z][a-z]+)\%[^|$%.]*\<(?<Product>\w+)\>[^|$%.]*\|(?<Count>\d+)\|[^|$%.]*?(?<Price>\d+(?:\.\d+)?)\$";
        string input;
        decimal totalPrice = 0;

        while ((input = Console.ReadLine()) != "end of shift")
        {
            foreach (Match match in Regex.Matches(input, pattern))
            {
                Product newProduct = new Product(
                    match.Groups["Customer"].Value,
                    match.Groups["Product"].Value,
                    int.Parse(match.Groups["Count"].Value),
                    decimal.Parse(match.Groups["Price"].Value));

                products.Add(newProduct);
                totalPrice += newProduct.Price * newProduct.Count;
                Console.WriteLine($"{newProduct.Customer}: {newProduct.Name} - {newProduct.Price * newProduct.Count:F2}");
            }
        }

        Console.WriteLine($"Total income: {totalPrice:F2}");
    }

    class Product
    {
        public string Customer { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public Product(string customer, string name, int count, decimal price)
        {
            Customer = customer;
            Name = name;
            Count = count;
            Price = price;
        }
    }
}

