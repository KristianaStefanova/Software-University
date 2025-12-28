using System.Data;

class Program
{
    static void Main(string[] args)
    {
        string number;

        while ((number = Console.ReadLine()) != "END")
        {
            Console.WriteLine(GetPalindrome(number));
        }
    }

    static bool GetPalindrome(string palindromeString)
    {
        string leftPart = palindromeString.Substring(0, palindromeString.Length / 2);
        string stringReversed = ReverseString(palindromeString);
        string rightPart = stringReversed.Substring(0, stringReversed.Length / 2);

        return leftPart == rightPart;
    }

    private static string ReverseString(string palindromeString)
    {
        char[] arr = palindromeString.ToCharArray();
        Array.Reverse(arr);

        return new string(arr);
    }
}

