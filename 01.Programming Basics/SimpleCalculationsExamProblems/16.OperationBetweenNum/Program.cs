int n1 = int.Parse(Console.ReadLine());
int n2 = int.Parse(Console.ReadLine());
char operation = char.Parse(Console.ReadLine());

double result = 0;
string numberIs = "";

if (operation == '+' || operation == '-' || operation == '*')
{
    if (operation == '+')
    {
        result = n1 + n2;
    }
    else if (operation == '-')
    {
        result = n1 - n2;
    }
    else if (operation == '*')
    {
        result = n1 * n2;
    }

    if (result % 2 == 0)
    {
        numberIs = "even";
    }
    else
    {
        numberIs = "odd";
    }

    Console.WriteLine($"{n1} {operation} {n2} = {result} – {numberIs}");
}
else if (operation == '/' || operation == '%')
{
    if (n2 == 0)
    {
        Console.WriteLine($"Cannot divide {n1} by zero");
    }
    if (operation == '/')
    {
        result = (double)n1 / n2;
        Console.WriteLine($"{n1} / {n2} = {result:F2}");
    }
    else if (operation == '%')
    {
        result = n1 % n2;
        Console.WriteLine($"{n1} % {n2} = {result}");
    }
}
