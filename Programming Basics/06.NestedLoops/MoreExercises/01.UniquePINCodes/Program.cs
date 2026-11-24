using System.Diagnostics.Metrics;

int borderFirstNum = int.Parse(Console.ReadLine()); 
int borderSecondNum = int.Parse(Console.ReadLine());    
int borderThurdNum = int.Parse(Console.ReadLine());

int counerPrimeNum = 0;

for (int i = 2; i <= borderFirstNum; i+=2)
{
    
    for (int j = 2; j <= borderSecondNum; j++)
    {

        for (int n = 2; n <= j; n++)
        {
            if (j % n == 0)
            {
                counerPrimeNum++;
                
            }
        }

        for (int k = 2; k <= borderThurdNum; k += 2)
        {
            if (counerPrimeNum < 2)
            {
            Console.WriteLine($"{i} {j} {k}");

            }
        }
         counerPrimeNum = 0;
    }
}