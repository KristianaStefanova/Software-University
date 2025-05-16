using System.Runtime.Intrinsics.X86;

string season = Console.ReadLine();
string group = Console.ReadLine();
int countOfStudents = int.Parse(Console.ReadLine());
int countOfDays = int.Parse(Console.ReadLine());

double totalMoney = 0.0;
string sport = "";

if (season == "Winter")
{
	switch (group)
	{
		case "boys":
            totalMoney = countOfDays * countOfStudents * 9.60;
            sport = "Judo";
            break;
            
		case "girls":
            totalMoney = countOfDays * countOfStudents * 9.60;
            sport = "Gymnastics";

            break;
		case "mixed":
            totalMoney = countOfDays * countOfStudents * 10.00;
            sport = "Ski";
            break;
	}
}
else if (season == "Spring")
{
    switch (group)
    {
        case "boys":
            totalMoney = countOfDays * countOfStudents * 7.20;
            sport = "Tennis";
            break;
        case "girls":
            totalMoney = countOfDays * countOfStudents * 7.20;
            sport = "Athletics";
            break;
        case "mixed":
            totalMoney = countOfDays * countOfStudents * 9.50;
            sport = "Cycling";
            break;
    }
}
else if (season == "Summer")
{
    switch (group)
    {
        case "boys":
            totalMoney = countOfDays * countOfStudents * 15.00;
            sport = "Football";
            break;
        case "girls":
            totalMoney = countOfDays * countOfStudents * 15.00;
            sport = "Valleyball";
            break;
        case "mixed":
            totalMoney = countOfDays * countOfStudents * 20.00;
            sport = "Swimming";
            break;
    }
}

if (countOfStudents >= 50)
{
    totalMoney /= 2;
}
else if (countOfStudents >= 20 && countOfStudents < 50)
{
    totalMoney *= 0.85;
}
else if (countOfStudents >= 10 && countOfStudents < 20)
{
    totalMoney *= 0.95;
}

Console.WriteLine($"{sport} {totalMoney:F2} lv.");