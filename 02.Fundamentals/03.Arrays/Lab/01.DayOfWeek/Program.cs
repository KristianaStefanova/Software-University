using System.Globalization;

class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        string[] days =
            {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"
            };

        if (number >= 1 && number <= days.Length)
        {
            int index = number - 1;
            Console.WriteLine(days[index]);
        }
        else
        {
            Console.WriteLine("Invalid day!");
        }
    }
}

