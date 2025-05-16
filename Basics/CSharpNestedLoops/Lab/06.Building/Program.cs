int floors = int.Parse(Console.ReadLine()); 
int numRooms  = int.Parse(Console.ReadLine());

for (int floor = floors; floor >= 1; floor--)
{
	for (int room = 0; room < numRooms; room++)
	{
		if (floor == floors)
		{
            Console.Write($"L{floor}{room} ");
        }
		else if (floor % 2 == 0)
		{
			Console.Write($"O{floor}{room} ");
		}
		else 
        {
			Console.Write($"A{floor}{room} ");
		}
	}

	Console.WriteLine();
} 