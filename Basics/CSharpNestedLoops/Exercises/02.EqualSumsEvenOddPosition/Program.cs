int start = int.Parse(Console.ReadLine());
int end = int.Parse(Console.ReadLine());

for (int i = start; i <= end; i++)
{
    string currentNum = i.ToString();

   int sumOdd = 0;
   int sumEven = 0;

    for (int j = 0; j < currentNum.Length; j++)
    {
        int currentDigit = int.Parse(currentNum[j].ToString());

        if (j % 2 == 0)
        {
            sumOdd += currentDigit;
        }
        else
        {
            sumEven += currentDigit;
        }
    } 
    if(sumOdd == sumEven)
    { 
        Console.Write(currentNum + " ");
    }
} 