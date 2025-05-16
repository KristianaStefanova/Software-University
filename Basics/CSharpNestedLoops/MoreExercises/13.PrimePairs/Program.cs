int startFirstCouple = int.Parse(Console.ReadLine()); 
int startSecondCouple = int.Parse(Console.ReadLine());
int diffFirstCouple= int.Parse(Console.ReadLine());
int diffSecondCouple = int.Parse(Console.ReadLine());

int finishFirstCouple = startFirstCouple + diffFirstCouple;
int finshSecondCouple = startSecondCouple + diffSecondCouple;

int counterFirsetNum = 0;
int counterSecondNum = 0;
bool primeNumFirstNum = false;
bool primeNumSecondNum = false;

for (int i = startFirstCouple; i <= finishFirstCouple; i++)
{
    
    for (int s = startSecondCouple; s <= finshSecondCouple; s++)
    {
        for (int n = 2; n < i; n++)
        {
            if (i % n == 0)
            {
                counterFirsetNum++;

            }

        }
        if (counterFirsetNum < 1)
        {
            primeNumFirstNum = true;
            for (int n = 2; n < s; n++)
            {
                if (s % n == 0)
                {
                    counterSecondNum++;

                }

            }
            if (counterSecondNum < 1)
            {
                primeNumSecondNum = true;
                if (primeNumFirstNum == true && primeNumSecondNum == true)
                {
                    Console.WriteLine($"{i}{s}");
                }
            }


           
        }
            counterSecondNum = 0;
            counterFirsetNum = 0;
    }
        


}

