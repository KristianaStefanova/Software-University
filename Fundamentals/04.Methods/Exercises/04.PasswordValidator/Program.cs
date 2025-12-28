


class Program
{
    static void Main()
    {
        string password = Console.ReadLine();

        bool validSize = ValidationSize(password);
        bool validSymbols = ValidationLettersAndDigits(password);
        bool validCountOfDigits = ValidationCountOfDigits(password);

        if (!validSize)
        {
            Console.WriteLine("Password must be between 6 and 10 characters");
        }
        if (!validSymbols)
        {
            Console.WriteLine("Password must consist only of letters and digits");
        }
        if (!validCountOfDigits)
        {
            Console.WriteLine("Password must have at least 2 digits");
        }
        if (validSize && validSymbols && validCountOfDigits)
        {
            Console.WriteLine("Password is valid");
        }
    }

    static bool ValidationCountOfDigits(string password)
    {
        int counter = 0;

        foreach (char symbol in password)
        {
            if (symbol >= 48 && symbol <= 57)
            {
                counter++;
            }
        }

        if (counter >= 2 )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static bool ValidationLettersAndDigits(string password)
    {
        foreach (char charecter in password)
        {
            if ((charecter >= 48 && charecter <= 57) ||
                (charecter >= 65 && charecter <= 90) ||
                (charecter >= 97 && charecter <= 122 ))
            {
                continue;
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    static bool ValidationSize(string password)
    {
        if (password.Length < 6 || password.Length > 10)
        {          
            return false;
        }

        return true;
    }
}

