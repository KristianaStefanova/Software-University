int firstNum = int.Parse(Console.ReadLine());
int secindNum = int.Parse(Console.ReadLine());
int thirdNum = int.Parse(Console.ReadLine());
int counterPrimeNum = 0;

for (int first = 1; first <= firstNum; first++)
{
    for (int second = 2; second <= secindNum; second++)
    {
        
        for (int n = 2; n <= second; n++)
        {
            if (second % n == 0)
            {
                counterPrimeNum++;
            }
        }
        for (int third = 1; third <= thirdNum; third++)
        {
            if (third % 2 == 0 && first % 2 == 0)
            {
                if (counterPrimeNum < 2)
                Console.WriteLine($"{first} {second} {third}");
                
            }
            
        }
        counterPrimeNum = 0;
    }
}