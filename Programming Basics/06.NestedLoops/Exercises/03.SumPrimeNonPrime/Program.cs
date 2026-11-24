int sumPrimeNums = 0;
int sumNonPrimeNums = 0;

while (true)
{
    string input = Console.ReadLine();

    if (input == "stop")
    {
        break;
    }

    int currentNum = int.Parse(input);
    int counter = 0;

    if (currentNum < 0)
    {
        Console.WriteLine("Number is negative.");
        continue;
    }
    for (int i = 1; i <= currentNum; i++)
    {
        if (currentNum % i == 0)
        {
            counter++;
        }
    }
    if (counter == 2)
    {
        sumPrimeNums += currentNum;
    }
    else if (counter > 2)
    {
        sumNonPrimeNums += currentNum;
    }
}
Console.WriteLine($"Sum of all prime numbers is: {sumPrimeNums}");
Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrimeNums}");
