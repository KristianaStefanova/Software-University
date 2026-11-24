string num = Console.ReadLine();

int maxNum = int.MinValue;

while (num != "Stop")
{
  int currentNum = int.Parse(num);

    if (currentNum > maxNum)
    {
        maxNum = currentNum;
    }

    num = Console.ReadLine();
}
Console.WriteLine(maxNum);