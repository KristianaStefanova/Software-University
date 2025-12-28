
class Program
{
    static void Main(string[] args)
    {
        double firstNumber = double.Parse(Console.ReadLine());
        char operation = char.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());

        Console.WriteLine(Calculation(firstNumber, operation, secondNumber));
    }

    static double Calculation(double firstNumber, char operation, double secondNumber)
    {
        switch (operation)
        {
            case '/':
                {
                    return firstNumber / secondNumber;
                }
            case '*':
                {
                    return firstNumber * secondNumber;
                }
            case '+':
                {
                    return firstNumber + secondNumber;
                }
            default:
                {
                    return firstNumber - secondNumber;
                }
        }
    }
}

