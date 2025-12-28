using System.Text;

namespace demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            decimal totalSum = 0;

            foreach (string str in input)
            {
                char firstLetter = str[0];
                char secondLetter = str[str.Length - 1];

                int number = int.Parse(str.Substring(1, str.Length - 2));

                int position = 0;
                decimal result = 0;

                if (char.IsUpper(firstLetter))
                {
                    position = firstLetter - 'A' + 1;
                    result = (decimal)number / position;
                }
                else if(char.IsLower(firstLetter))
                {
                    position = firstLetter - 'a' + 1;
                    result = (decimal)number * position;
                }

                if (char.IsUpper(secondLetter))
                {
                    position = secondLetter - 'A' + 1;
                    result -= position;
                }
                else if (char.IsLower(secondLetter))
                {
                    position = secondLetter - 'a' + 1;
                    result += position;
                }

                totalSum += result;
            }

            Console.WriteLine($"{totalSum:F2}");
        }
    }
}
