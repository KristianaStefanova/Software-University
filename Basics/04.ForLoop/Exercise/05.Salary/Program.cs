int openSites = int.Parse(Console.ReadLine());
double salary = double.Parse(Console.ReadLine());

for (int i = 0; i < openSites; i++)
{
    string currentSites = Console.ReadLine();

    switch (currentSites)
    {
        case "Facebook":
            salary -= 150;
            break;
        case "Instagram":
            salary -= 100;
            break;
        case "Reddit":
            salary -= 50;
            break;
    }
    if (salary <= 0)
    {
        break;
    }
}
if (salary > 0)
{
    Console.WriteLine(salary);
}
else
{
    Console.WriteLine("You have lost your salary.");
}