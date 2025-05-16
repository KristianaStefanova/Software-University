int countOfChrysanthemum = int.Parse(Console.ReadLine());
int countOfRoses = int.Parse(Console.ReadLine());
int countOfTulip = int.Parse(Console.ReadLine());
string season = Console.ReadLine();
char day = char.Parse(Console.ReadLine());

double money = 0.0;
int allFlowers = countOfChrysanthemum + countOfRoses + countOfTulip;
int arrangement = 2;

if (season == "Spring" || season == "Summer")
{
    money += countOfChrysanthemum * 2.00;
    money += countOfRoses * 4.10;
    money += countOfTulip * 2.50;
}
else if (season == "Autumn" || season == "Winter")
{
    money += countOfChrysanthemum * 3.75;
    money += countOfRoses * 4.50;
    money += countOfTulip * 4.15;
}
if (day == 'Y')
{
    money *= 1.15;
}
if (countOfTulip > 7 && season == "Spring")
{
    money *= 0.95;
}
if (countOfRoses >= 10 && season == "Winter")
{
    money *= 0.90;
}
if (allFlowers > 20)
{
    money *= 0.80;
}

money += arrangement;

Console.WriteLine($"{money:F2}");