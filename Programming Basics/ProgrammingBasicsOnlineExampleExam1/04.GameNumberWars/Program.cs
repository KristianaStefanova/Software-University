string namePlayer1 = Console.ReadLine();
string namePlayer2 = Console.ReadLine();

int pointsFirstPlayer = 0;
int pointsSecondPlayer = 0;
int allPointFirstPlayer = 0;
int allPointSecondPlayer = 0;

for (int i = 1; i <= 18; i++)
{
    string input = Console.ReadLine();

    if (input == "End of game")
    {
        Console.WriteLine($"{namePlayer1} has {allPointFirstPlayer} points");
        Console.WriteLine($"{namePlayer2} has {allPointSecondPlayer} points");
        break;
    }
    int cardFirstPlayer = int.Parse(input);
    int cardSecondPlayer = int.Parse(Console.ReadLine());

    if (cardFirstPlayer == cardSecondPlayer)
    {
        int numberWars1 = int.Parse(Console.ReadLine());
        int numberWars2 = int.Parse(Console.ReadLine());

        if (numberWars1 > numberWars2)
        {
            Console.WriteLine("Number wars!");
            Console.WriteLine($"{namePlayer1} is winner with {allPointFirstPlayer} points");
            break;
        }
        else if (numberWars2 > numberWars1)
        {
            int allWarsSecondplayer = numberWars2 - numberWars1;

            Console.WriteLine("Number wars!");
            Console.WriteLine($"{namePlayer2} is winner with {allPointSecondPlayer} points");
            break;
        }
    }
    if (cardFirstPlayer > cardSecondPlayer)
    {
        pointsFirstPlayer = cardFirstPlayer - cardSecondPlayer;
        allPointFirstPlayer += pointsFirstPlayer;
    }
    else if (cardSecondPlayer > cardFirstPlayer)
    {
        pointsSecondPlayer = cardSecondPlayer - cardFirstPlayer;
        allPointSecondPlayer += pointsSecondPlayer;
    }

}