int eggs = int.Parse(Console.ReadLine());
int eggsSold = 0;

while (true)
{
    string text = Console.ReadLine();
    
    if (text == "Close")
    {
        Console.WriteLine("Store is closed!");
        Console.WriteLine($"{eggsSold} eggs sold.");
        break;
    }

    int number = int.Parse(Console.ReadLine());

    if (text == "Buy")
    {
        if (eggs < number)
        {
            Console.WriteLine("Not enough eggs in store!");
            Console.WriteLine($"You can buy only {eggs}.");
            break;
        }
        eggsSold += number;
        eggs -= number;
    }
    else if (text == "Fill")
    {
        eggs += number;
    }
}