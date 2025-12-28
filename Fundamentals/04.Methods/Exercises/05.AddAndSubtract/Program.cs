
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        int firstNum = int.Parse(Console.ReadLine());
        int secondNum = int.Parse(Console.ReadLine());
        int thirdNum = int.Parse(Console.ReadLine());

        int result = AddTwoNumbers(firstNum, secondNum);
        result = SubtractTwoNumbers(result, thirdNum);

        Console.WriteLine(result);
    }

    static int SubtractTwoNumbers(int a, int b)
    {
        int result = a - b;

        return result;
    }

    static int AddTwoNumbers(int a, int b)
    {
        int result = a + b;

        return result;
    }
}

