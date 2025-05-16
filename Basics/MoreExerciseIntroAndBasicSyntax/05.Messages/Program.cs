using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            char ch = ' ';
            int length = input.Length;
            int mainDigit = input[0] - '0';

            if (mainDigit == 0)
            {
                Console.Write(ch);
                continue;
            }
            int offset = 0;

            if (mainDigit == 8 || mainDigit == 9)
            {
                offset = (mainDigit - 2) * 3;
                offset++;
            }
            else if (mainDigit != 8 || mainDigit != 9)
            {
                offset = (mainDigit - 2) * 3;
            }

            int letterIndex = (offset + length - 1) + 'a';
            ch = (char)letterIndex;
            Console.Write(ch);
        }
    }
}

