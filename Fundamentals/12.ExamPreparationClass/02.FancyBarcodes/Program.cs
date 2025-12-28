using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());

        string validPattern = @"\@#+[A-Z][A-Za-z0-9]{4,}[A-Z]\@#+";

        for (int i = 0; i < count; i++)
        {
            string barcode = Console.ReadLine();

            if (!Regex.IsMatch(barcode, validPattern))
            {
                Console.WriteLine("Invalid barcode");
                continue;
            }

            char[] digits = barcode.Where(c => char.IsDigit(c)).ToArray();

            string productGroup = digits.Length > 0
                ? new string(digits)
                : "00";

            Console.WriteLine($"Product group: {productGroup}");
        }
    }
}

