using System.ComponentModel.Design;

char finalSector = char.Parse(Console.ReadLine());  
int countOfRowsFirstSector = int.Parse(Console.ReadLine());    
int countOfSeatsEvenRow = int.Parse(Console.ReadLine());

int countOfSeatsOddRows = countOfSeatsEvenRow + 2;
int counter = 0;

for (char sector = 'A'; sector <= finalSector; sector++)
{
    
    for (int row = 1; row <= countOfRowsFirstSector; row++)
	{
        
	    if (row % 2 == 0)
	    {
            for (char seats = 'a'; seats < 'a' + countOfSeatsOddRows; seats++)
		    {
                Console.WriteLine($"{sector}{row}{seats}");
                counter++;
            }
        }
		else
		{
            for (char seats = 'a'; seats < 'a' + countOfSeatsEvenRow; seats++)
            {
                Console.WriteLine($"{sector}{row}{seats}");
                counter++;
            }
        }
	}
	countOfRowsFirstSector++;
}
Console.WriteLine(counter);