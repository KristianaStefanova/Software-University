using System.Text;

class Program
{
    static void Main()
    {
        //string input = Console.ReadLine();

        //char[] encryptedVersion = new char[input.Length];
        //int i = 0;


        //foreach (char character in input)
        //{
        //    encryptedVersion[i] += (char)(character + 3);
        //    i++;
        //}
        //Console.Write(encryptedVersion);

        string input = Console.ReadLine();

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            char originalChar = input[i];

            sb.Append((char)(originalChar + 3));
        }

        Console.WriteLine(sb.ToString());

    }
}

