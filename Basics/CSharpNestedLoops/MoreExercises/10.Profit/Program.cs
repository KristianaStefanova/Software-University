int coions1Lv = int.Parse(Console.ReadLine());
int coions2Lv = int.Parse(Console.ReadLine());
int banknote5Lv = int.Parse(Console.ReadLine());
int sum = int.Parse(Console.ReadLine());




for (int lev = 0; lev <= coions1Lv; lev++)
{
    
    for (int twoLevas = 0; twoLevas <= coions2Lv; twoLevas++)
    {
        for (int fiveLevas = 0; fiveLevas <= banknote5Lv; fiveLevas++)
        {
            if (lev * 1 + twoLevas * 2 + fiveLevas * 5 == sum)
            {
                Console.WriteLine($"{lev} * 1 lv. + {twoLevas} * 2 lv. + {fiveLevas} * 5 lv. = {sum} lv.");
            }
        }
    }
}