using System.Text;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        StringBuilder result = new StringBuilder();

        int strength = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '>')
            {
                result.Append(input[i]);
                strength += int.Parse(input[i + 1].ToString());
            }
            else if (strength == 0)
            {
                result.Append(input[i]);
            }
            else
            {
                strength--;
            }
        }

        Console.WriteLine(result.ToString());
    }
}

