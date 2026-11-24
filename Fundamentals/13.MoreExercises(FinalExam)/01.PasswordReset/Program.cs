using System.Collections.Specialized;
using System.Data.SqlTypes;
using System.Text;

class Program
{
    static void Main()
    {
        string password = Console.ReadLine();

        string result = password;
        string command = null;
        
        while ((command = Console.ReadLine()) != "Done")
        {
            string[] arguments = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string action = arguments[0];
            switch (action)
            {
                case "TakeOdd":
                    result = TakeOdd(result);
                    break;
                case "Cut":
                    result = Cut(int.Parse(arguments[1]), int.Parse(arguments[2]), result);
                    break;
                case "Substitute":
                    result = Substitute(arguments[1], arguments[2], result);
                    break;
            }
        }

        Console.WriteLine($"Your password is: {result}");
    }

    private static string Substitute(string substring, string substitute, string password)
    {
        if (!password.Contains(substring))
        {
            Console.WriteLine("Nothing to replace!");
            return password;
        }

        password = password.Replace(substring, substitute);
        Console.WriteLine(password);

        return password;
    }

    private static string Cut(int index, int length, string password)
    {
        //string substring = password.Substring(index, length);

        //int substringIndex = password.IndexOf(substring);

        //if (substringIndex != -1)
        //{
        //    password = password.Remove(substringIndex, substring.Length);
        //}
        //Console.WriteLine(password);
        //return password;

        password = password.Remove(index, length);
        Console.WriteLine(password);

        return password;
    }

    private static string TakeOdd(string password)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 1; i <= password.Length - 1; i++)
        {
            if (i % 2 != 0)
            {
                sb = sb.Append(password[i]);
            }
        }

        Console.WriteLine(sb.ToString());

        return sb.ToString();
    }
}

