int starttNum = int.Parse(Console.ReadLine());
int lastNum = int.Parse(Console.ReadLine());

int firstNumStart = starttNum / 1000;
int secondNumStart = starttNum / 100 % 10;
int thirdNumStart = starttNum / 10 % 10;
int fourthNumStart = starttNum % 10;
int firstNumLast = lastNum / 1000;
int secondNumLast = lastNum / 100 % 10;
int thirdNumLast = lastNum / 10 % 10;
int fourthNumLast = lastNum % 10;

for (int i = firstNumStart; i <= firstNumLast; i++)
{
    if (i % 2 == 0)
    {
        continue;
    }

    for (int j = secondNumStart; j <= secondNumLast; j++)
    {
        if (j % 2 == 0)
        {
            continue;
        }
        for (int k = thirdNumStart; k <= thirdNumLast; k++)
        {
            if (k % 2 == 0)
            {
                continue;
            }
            for (int l = fourthNumStart; l <= fourthNumLast; l++)
            {
                if (l % 2 == 0)
                {
                    continue;
                }
                Console.Write($"{i}{j}{k}{l} ");
            }
        }
    }
}
