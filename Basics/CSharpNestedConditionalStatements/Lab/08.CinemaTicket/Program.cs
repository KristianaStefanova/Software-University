string dayOfWeek = Console.ReadLine();
int price;
if (dayOfWeek == "Monday" || dayOfWeek == "Tuesday" || dayOfWeek == "Friday")
{
    price = 12;
}
else if (dayOfWeek == "Wednesday" || dayOfWeek == "Thursday")
{
    price = 14;
}
else 
{
    price = 16;
}

Console.WriteLine(price);