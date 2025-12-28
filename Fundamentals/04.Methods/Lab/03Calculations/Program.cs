
class Program
{
    static void Main()
    {
        string operation = Console.ReadLine();
        int firstNumber = int.Parse(Console.ReadLine());
        int secondtNumber = int.Parse(Console.ReadLine());

        switch (operation)
        {
            case "add":
                PrintAddedNumbers(firstNumber, secondtNumber);
                break;
            case "multiply":
                PrintMultipliedNumbers(firstNumber, secondtNumber);
                break;
            case "subtract":
                PrintSubtractedNumbers(firstNumber, secondtNumber);
                break;
            case "divide":
                PrintDividedNumbers(firstNumber, secondtNumber); 
                break;
        }
    }

    private static void PrintAddedNumbers(int firstNumber, int secondNumber)
    {
        int result = firstNumber + secondNumber;
        Console.WriteLine(result);
    }
    private static void PrintMultipliedNumbers(int firstNumber, int secondNumber)
    {
        int result = firstNumber * secondNumber;
        Console.WriteLine(result);
    }
    private static void PrintSubtractedNumbers(int firstNumber, int secondNumber)
    {
        int result = firstNumber - secondNumber;
        Console.WriteLine(result);
    }
    private static void PrintDividedNumbers(int firstNumber, int secondNumber)
    {
        int result = firstNumber / secondNumber;
        Console.WriteLine(result);
    }
}

