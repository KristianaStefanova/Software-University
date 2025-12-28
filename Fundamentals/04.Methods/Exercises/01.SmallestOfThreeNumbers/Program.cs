
class Program
{
    static void Main()
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());
        int thirdNumber = int.Parse(Console.ReadLine());

        int smallestNum = GetSmallestNumber(firstNumber, secondNumber);
        smallestNum = GetSmallestNumber(smallestNum, thirdNumber);

        Console.WriteLine(smallestNum);
    }

    static int GetSmallestNumber(int a, int b)
    {
        if (a < b)
        {
            return a;
        }
        else
        {
            return b;
        }
    }
}

