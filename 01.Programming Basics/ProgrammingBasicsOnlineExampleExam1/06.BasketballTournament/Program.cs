using System.Collections.Generic;
using System.Text.RegularExpressions;

int winMatches = 0;
int lostMatches = 0;

bool flag = false;
string nameOfTournament = Console.ReadLine();

while (nameOfTournament != "End of tournaments")
{
    int pointsDesiDiff = 0;
    int pointsRevelsDiff = 0;

    int counterMatches = 0;
    int countOfMatches = int.Parse(Console.ReadLine());

    for (int i = 1; i <= countOfMatches; i++)
    { 
        int pointsTeamDesi = int.Parse(Console.ReadLine());
        counterMatches++;
        
        int pointsTeamRevals = int.Parse(Console.ReadLine()); 
        
        if (pointsTeamDesi > pointsTeamRevals)
        {
            winMatches++;
            pointsDesiDiff = pointsTeamDesi - pointsTeamRevals;
            Console.WriteLine($"Game {counterMatches} of tournament {nameOfTournament}: win with {pointsDesiDiff} points.");
        }
        else if (pointsTeamRevals > pointsTeamDesi)
        {
            lostMatches++;
            pointsRevelsDiff = pointsTeamRevals - pointsTeamDesi;
            Console.WriteLine($"Game {counterMatches} of tournament {nameOfTournament}: lost with {pointsRevelsDiff} points.");
        }
    }

    nameOfTournament = Console.ReadLine();
}

if (nameOfTournament == "End of tournaments")
{
    int allPlayedMatches = winMatches + lostMatches;
    double percentMatchesWin = (double)winMatches / allPlayedMatches * 100;
    Console.WriteLine($"{percentMatchesWin:F2}% matches win");

    double percentLostMatches = (double)lostMatches / allPlayedMatches * 100;
    Console.WriteLine($"{percentLostMatches:F2}% matches lost");
}