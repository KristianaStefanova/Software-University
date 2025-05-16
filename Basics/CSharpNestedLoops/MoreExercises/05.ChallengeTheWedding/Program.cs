int countOfMen = int.Parse(Console.ReadLine()); 
int countOfWomen = int.Parse(Console.ReadLine()); 
int maxNumTables = int.Parse(Console.ReadLine());
int counterTables = 0;

for (int munMan = 1; munMan <= countOfMen; munMan++)
{
    for (int numWoman = 1; numWoman <= countOfWomen; numWoman++)
    {
        Console.Write($"({munMan} <-> {numWoman}) ");
        counterTables++;
        if (counterTables == maxNumTables)
        {
            return;
        }
    }
}