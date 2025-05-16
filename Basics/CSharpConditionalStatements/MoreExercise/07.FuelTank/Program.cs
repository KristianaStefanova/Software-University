string fuel = Console.ReadLine().ToLower();
int avalableFuel = int.Parse(Console.ReadLine());

if (fuel == "diesel" || fuel == "gasoline" || fuel == "gas")
{
    if (avalableFuel >= 25 && (fuel == "diesel" || fuel == "gasoline" || fuel == "gas"))
    {
        Console.WriteLine($"You have enough {fuel}.");
    }
    else if (avalableFuel < 25 && (fuel == "diesel" || fuel == "gasoline" || fuel == "gas"))
    {
        Console.WriteLine($"Fill your tank with {fuel}!");
    }
}
else
{
    Console.WriteLine("Invalid fuel!");
}