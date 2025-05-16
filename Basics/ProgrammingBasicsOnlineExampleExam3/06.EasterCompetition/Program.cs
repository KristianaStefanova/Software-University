int countOfKuzunak = int.Parse(Console.ReadLine());

string nameWinner = "";

int winner = 0;
for (int i = 0; i < countOfKuzunak; i++)
{
    int sumAllGrades = 0;

    string nameChef = Console.ReadLine();
    
    while (true)
    {
        string input = Console.ReadLine();
        if (input == "Stop")
        {
            Console.WriteLine($"{nameChef} has {sumAllGrades} points.");

            if (sumAllGrades > winner)
            {
                winner = sumAllGrades;
                nameWinner = nameChef;

                Console.WriteLine($"{nameChef} is the new number 1!");
            }
            break;
        }
        int grade = int.Parse(input);

        sumAllGrades += grade;
    }
}

Console.WriteLine($"{nameWinner} won competition with {winner} points!");