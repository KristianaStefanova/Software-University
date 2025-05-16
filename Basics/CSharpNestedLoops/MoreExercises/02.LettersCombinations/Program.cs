char start = char.Parse(Console.ReadLine());
char final = char.Parse(Console.ReadLine());
char missingChar = char.Parse(Console.ReadLine());
int counter = 0;	

for (char d1 = start; d1 <= final; d1++)
{
	for (char d2 = start; d2 <= final; d2++)
	{
		for (char d3 = start; d3 <= final; d3++)
		{
			if (d1 == missingChar || d2 == missingChar || d3 == missingChar)
			{
				continue;
			}
			else
			{
				counter++;
            Console.Write($"{d1}{d2}{d3} ");

			}
        }
	}
}
Console.Write(counter);
