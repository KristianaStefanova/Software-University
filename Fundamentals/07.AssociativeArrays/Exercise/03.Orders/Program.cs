namespace _03.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            string command;

            while ((command = Console.ReadLine()) != "buy")
            {
                string[] arguments = command.Split();

                string name = arguments[0];
                decimal price = decimal.Parse(arguments[1]);
                int quantity = int.Parse(arguments[2]);

                Product product = new(name, price, quantity);

                if (!products.ContainsKey(name))
                {
                    products.Add(name, product);
                }
                else
                {
                    products[name].Update(quantity, price);
                }

            }

            foreach (KeyValuePair<string, Product> pair in products)
            {
                Console.WriteLine(pair.Value);
            }
        }
    }

    class Product
    {
        public Product(string name, decimal price, int quantity)
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
            get { return Price * Quantity; }
        }

        public void Update(int quantity, decimal price)
        {
            Price = price;
            Quantity += quantity;
        }

        public override string ToString()
        {
            return $"{Name} -> {TotalPrice:F2}";
        }
    }
}
