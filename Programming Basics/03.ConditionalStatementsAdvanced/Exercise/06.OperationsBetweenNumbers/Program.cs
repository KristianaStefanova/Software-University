int num1 = int.Parse(Console.ReadLine());
int num2 = int.Parse(Console.ReadLine());
char operation = char.Parse(Console.ReadLine());

double result = 0;

if (operation == '+' || operation == '-' || operation == '*')
{
    if (operation == '+')
    {
        result = num1 + num2;
    }
    else if (operation == '-')
    {
        result = num1 - num2;
    }
    else if (operation == '*')
    {
        result = num1 * num2;
    }

    string evenOrOdd = "even";

    if (result % 2 != 0)
    {
        evenOrOdd = "odd";
    }

    Console.WriteLine($"{num1} {operation} {num2} = {result} - {evenOrOdd}");
}
else if (operation == '/')
{
    result = (double)num1 / num2;

    if (num2 == 0)
    {
        Console.WriteLine($"Cannot divide {num1} by zero");
    }
    else
    {
        Console.WriteLine($"{num1} / {num2} = {result:f2}");
    }
}
else if (operation == '%')
{
    if (num2 == 0)
    {
        Console.WriteLine($"Cannot divide {num1} by zero");
    }
    else
    {
        result = num1 % num2;
        Console.WriteLine($"{num1} % {num2} = {result}");
    }
}