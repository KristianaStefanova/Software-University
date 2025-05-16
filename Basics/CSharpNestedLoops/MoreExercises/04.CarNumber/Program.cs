int start = int.Parse(Console.ReadLine());
int end = int.Parse(Console.ReadLine());

for (int i = start; i <= end; i++)
{

	for (int j = start; j <= end; j++)
	{
		for (int k = start; k <= end; k++)
		{
			for (int l = start; l <= end; l++)
			{
				
				
				if (i > l)
				{
					if (i % 2 == 0 && l % 2 != 0)
					{
						if ((j + k) % 2 == 0)
						{
                            Console.Write($"{i}{j}{k}{l} ");
                        }
					}
					else if (i % 2 != 0 && l % 2 == 0)
					{
                        if ((j + k) % 2 == 0)
                        {
                            Console.Write($"{i}{j}{k}{l} ");
                        }
                    }

                }

				
			}
		}
	}
}