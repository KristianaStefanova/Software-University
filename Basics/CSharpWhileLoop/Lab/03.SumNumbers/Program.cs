int num = int.Parse(Console.ReadLine());

int sum = 0;

while (true)
{
    int currentNum = int.Parse(Console.ReadLine());
    sum += currentNum;
    if (sum >= num)
    {
        break;
    } 
}

Console.WriteLine(sum);