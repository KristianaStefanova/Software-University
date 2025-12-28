class Program
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());

        string balance = "UNBALANCED";
        string checkBrackets = "";

        for (int i = 1; i <= count; i++)
        {
            string bracket = Console.ReadLine();
            if (bracket == ")" || bracket == "(")
            {
                checkBrackets += bracket;
            }

            if (checkBrackets == "()")
            {
                balance = "BALANCED";
                checkBrackets = "";
            }
            else if (bracket != "(" && bracket != ")")
            {
                continue;
            }
            else
            {
                balance = "UNBALANCED";
            }
        }

        Console.WriteLine(balance);
    }
}
    

