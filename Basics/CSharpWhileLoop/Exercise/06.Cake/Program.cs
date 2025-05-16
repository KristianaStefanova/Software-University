int length = int.Parse(Console.ReadLine());
int large = int.Parse(Console.ReadLine());

int sizeCake = length * large;
int piecesLeft = 0;
int allPieces = 0;

while (sizeCake > 0)
{
    string input = Console.ReadLine();
    if (input == "STOP")
    {
        break;
    }

    int piecesTaken = int.Parse(input);

    sizeCake -= piecesTaken;
    allPieces += piecesTaken;
}
if (sizeCake > 0)
{
    Console.WriteLine($"{sizeCake} pieces are left.");
}
else
{
    Console.WriteLine($"No more cake left! You need {Math.Abs(sizeCake)} pieces more.");
}