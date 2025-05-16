string n = Console.ReadLine();

int sumNum = 0;

for (int i = 0; i < n.Length; i++)
{
    char letter = n[i];
    if (letter == 'a')
    {
        sumNum += 1;
    }
    else if (letter == 'e')
    {
        sumNum += 2;
    }
    else if (letter == 'i')
    {
        sumNum += 3;
    }
    else if (letter == 'o')
    {
        sumNum += 4;
    }
    else if (letter == 'u')
    {
        sumNum += 5;
    }
}

Console.WriteLine($"{sumNum}");