string num = Console.ReadLine();

int minNum = int.MaxValue;

while (num != "Stop")
{
    int currentNum = int.Parse(num);

    if (currentNum < minNum)
    {
        minNum = currentNum;
    }

    num = Console.ReadLine();
}
Console.WriteLine(minNum);