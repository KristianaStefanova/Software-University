int numOfClients = int.Parse(Console.ReadLine());
int counterProducts = 0;
double finalIncome = 0;
double averageBillPerClient = 0;

for (int i = 0; i < numOfClients; i++)
{
    string nameProduct = Console.ReadLine();
    int counterOneClient = 0;
    double billOneClient = 0;

    while (nameProduct != "Finish")
    {
        counterOneClient++;
        counterProducts++;

        if (nameProduct == "basket")
        {
            billOneClient += 1.50;
        }
        else if (nameProduct == "wreath")
        {
            billOneClient += 3.80;
        }
        else if (nameProduct == "chocolate bunny")
        {
            billOneClient += 7;
        }

        nameProduct = Console.ReadLine();
    }
    if (counterOneClient % 2 == 0)
    {
        billOneClient *= 0.8;
        finalIncome += billOneClient;
    }
    else
    {
        finalIncome += billOneClient;
    }
    Console.WriteLine($"You purchased {counterOneClient} items for {billOneClient:F2} leva.");
}

averageBillPerClient = finalIncome / numOfClients;

Console.WriteLine($"Average bill per client is: {averageBillPerClient:F2} leva.");