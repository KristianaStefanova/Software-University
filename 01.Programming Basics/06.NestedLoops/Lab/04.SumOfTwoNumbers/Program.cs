int startNum = int.Parse(Console.ReadLine());
int endNum = int.Parse(Console.ReadLine());
int magicNum = int.Parse(Console.ReadLine());

bool isFound = false;
int counter = 0;

for (int x1 = startNum; x1 <= endNum; x1++)
{
    int result;
    for (int x2 = startNum; x2 <= endNum; x2++)
    {
        result = x1 + x2;
        counter++;
        if (result == magicNum)
        {
            Console.WriteLine($"Combination N:{counter} ({x1} + {x2} = {magicNum})");
            isFound = true;
            break;
        }
    }
    if (isFound)
    {
        break;
    }
}
if (!isFound)
{
    Console.WriteLine($"{counter} combinations - neither equals {magicNum}");
}