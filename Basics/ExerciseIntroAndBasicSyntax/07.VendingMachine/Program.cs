class Program
{
    static void Main()
    {
        
        double money = 0.0;
        string command;
        while ((command = Console.ReadLine()) != "Start")
        {
            double coin = double.Parse(command);

            if (coin != 0.10 && coin != 0.2 && coin != 0.5 && coin != 1 && coin != 2)
            {
                Console.WriteLine($"Cannot accept {coin}");
                continue;
            }
            else
            {
                money += coin;
            } 
        }
            double priceNuts = 2;
            double priceWater = 0.7;
            double priceCrisps = 1.5;
            double priceSoda = 0.8;
            double priceCoke = 1;

        while ((command = Console.ReadLine()) != "End")
        {
            string productName = command;
            switch (productName)
            {
                case "Nuts":
                    if (money >= priceNuts)
                    {
                        money -= priceNuts;
                        Console.WriteLine($"Purchased nuts");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                        break;
                    }
                    break;
                case "Water":
                    if (money >= priceWater)
                    {
                        money -= priceWater;
                        Console.WriteLine($"Purchased water");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                        break;
                    }
                    break;
                case "Crisps":
                    if (money >= priceCrisps)
                    {
                        money -= priceCrisps;
                        Console.WriteLine($"Purchased crisps");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                        break;
                    }
                    break;
                case "Soda":
                    if (money >= priceSoda)
                    {
                        money -= priceSoda;
                        Console.WriteLine($"Purchased soda");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                        break;
                    }
                    break;
                case "Coke":
                    if (money >= priceCoke)
                    {
                        money -= priceCoke;
                        Console.WriteLine($"Purchased coke");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                        break;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid product");
                    break;
            }         
        }
        Console.WriteLine($"Change: {money:F2}");
    }
}

