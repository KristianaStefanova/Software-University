int countOfJuniors = int.Parse(Console.ReadLine());
int countOfSeniors = int.Parse(Console.ReadLine());
string typeOfRoad  = Console.ReadLine();

double money = 0.0;
int allPeople = countOfSeniors + countOfJuniors;

if (typeOfRoad == "trail")
{
    money += countOfJuniors * 5.50;
    money += countOfSeniors * 7.00;
}
else if (typeOfRoad == "cross-country")
{
    money += countOfJuniors * 8.00;
    money += countOfSeniors * 9.50;
}
else if (typeOfRoad == "downhill")
{
    money += countOfJuniors * 12.25;
    money += countOfSeniors * 13.75;
}
else if (typeOfRoad == "road")
{
    money += countOfJuniors * 20.00;
    money += countOfSeniors * 21.50;
}

if (allPeople >= 50 && typeOfRoad == "cross-country")
{
    money *= 0.75;
}
money *= 0.95;

Console.WriteLine($"{money:F2}");