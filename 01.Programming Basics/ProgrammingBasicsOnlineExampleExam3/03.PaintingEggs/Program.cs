string size = Console.ReadLine();
string color = Console.ReadLine();
int countOfBoxes = int.Parse(Console.ReadLine());
double income = 0;

if (color == "Red")
{
	switch (size)
	{
		case "Large": income = 16 * countOfBoxes;
			break;
		case "Medium": income = 13 * countOfBoxes;
			break;
		case "Small": income = 9 * countOfBoxes;
			break;
	}
}
else if (color == "Green") 
{
    switch (size)
    {
        case "Large": income = 12 * countOfBoxes;
            break;
        case "Medium": income = 9 * countOfBoxes;
            break;
        case "Small": income = 8 * countOfBoxes;
            break;
    }
}
else if (color == "Yellow")
{
    switch (size)
    {
        case "Large": income = 9 * countOfBoxes;
            break;
        case "Medium": income = 7 * countOfBoxes;
            break;
        case "Small": income = 5 * countOfBoxes;
            break;
    }
}

double finalIncome = income - (income * 0.35);
Console.WriteLine($"{finalIncome:F2} leva.");