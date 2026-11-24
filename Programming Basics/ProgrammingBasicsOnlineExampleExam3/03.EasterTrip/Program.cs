string destination = Console.ReadLine();    
string dates = Console.ReadLine();  
int countOfNights = int.Parse(Console.ReadLine());

double moneyForTrip = 0;

if (dates == "21-23")
{
    switch (destination)
    {
        case "France":
            moneyForTrip = countOfNights * 30;
            break;
        case "Italy":
            moneyForTrip = countOfNights * 28;
            break;
        case "Germany":
            moneyForTrip = countOfNights * 32;
            break;
    }
}
else if (dates == "24-27")
{
    switch (destination)
    {
        case "France":
            moneyForTrip = countOfNights * 35; break;
        case "Italy":
            moneyForTrip = countOfNights * 32; break;
        case "Germany":
            moneyForTrip = countOfNights * 37; break;
    }
}
else if (dates == "28-31")
{
    switch (destination)
    {
        case "France":
            moneyForTrip = countOfNights * 40;
            break;
        case "Italy":
            moneyForTrip = countOfNights * 39;
            break;
        case "Germany":
            moneyForTrip = countOfNights * 43;
            break;
    }
}
Console.WriteLine($"Easter trip to {destination} : {moneyForTrip:F2} leva.");
