int start = int.Parse(Console.ReadLine());
int end = int.Parse(Console.ReadLine());
int magicNum = int.Parse(Console.ReadLine());
bool isFound = false;
bool invalidNum = true;


int counter = 0;

for (int firstNum = start; firstNum <= end; firstNum++)
{
	invalidNum = false;
	for (int secondNum = start; secondNum <= end; secondNum++)
	{
		counter++;
		if (firstNum + secondNum == magicNum)
		{
            Console.WriteLine($"Combination N:{counter} ({firstNum} + {secondNum} = {magicNum})");
			isFound = true;
			break;
        }
	}
if (isFound)
{
    break;
}
	
}
if (invalidNum)
{
    Console.WriteLine($"{counter} combinations - neither equals {magicNum}");
    
}
else if (isFound == false)
{
    Console.WriteLine($"{counter} combinations - neither equals {magicNum}");
}

