string year = Console.ReadLine();
int holidays = int.Parse(Console.ReadLine());
int weekendsHome = int.Parse(Console.ReadLine());

int weekendsInSofia = 48 - weekendsHome;
double playSofia = (double)weekendsInSofia / 4 * 3 + (double)holidays / 3 * 2;
double playTotal = playSofia + weekendsHome;

if (year == "leap")
{
    playTotal *= 1.15;
}

Console.WriteLine($"{Math.Floor(playTotal)}");