using System.Numerics;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main()
    {
        Score score = new Score();

        score.Attendees = new List<int>(int.Parse(Console.ReadLine()));
        score.LecturesCount = int.Parse(Console.ReadLine());
        score.AdditionalBonus = int.Parse(Console.ReadLine());

        for (int i = 0; i < score.Attendees.Capacity; i++)
        {
            score.Attendees.Add(int.Parse(Console.ReadLine()));
        }

        score.CalculateMaxBonus();

        Console.WriteLine(score.ToString());
    }
}

class Score
{
    public int LecturesCount { get; set; }
    public int AdditionalBonus { get; set; }

    public double MaxBonus;

    public int MaxAttendees;

    public List<int> Attendees = new List<int>();

    public void CalculateMaxBonus()
    {
        for (int i = 0; i < Attendees.Count; i++)
        {
            double bonus = (double)Attendees[i] / LecturesCount * (5 + AdditionalBonus);
            bonus = Math.Ceiling(bonus);

            if (bonus > MaxBonus)
            {
                MaxBonus = bonus;
                MaxAttendees = Attendees[i];
            }
        }
    }

    public override string ToString()
    {
        return $"Max Bonus: {MaxBonus}.\nThe student has attended {MaxAttendees} lectures.";
    }
}

