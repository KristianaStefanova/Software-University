int countOfJoinery = int.Parse(Console.ReadLine());
string typeOfJoinery = Console.ReadLine();
string delivery = Console.ReadLine();

double finalPrice = 0;
bool invalidOrder = false;

if (countOfJoinery <= 10)
{
    invalidOrder = true;
    Console.WriteLine("Invalid order");
}

if (typeOfJoinery == "90X130")
{
    finalPrice = 110;

    if (countOfJoinery > 60)
    {
        finalPrice *= 0.92;
    }
    else if (countOfJoinery > 30)
    {
        finalPrice *= 0.95;
    }

    finalPrice *= countOfJoinery;
}
else if (typeOfJoinery == "100X150")
{
    finalPrice = 140;
    if (countOfJoinery > 80)
    {
        finalPrice *= 0.90;
    }
    else if (countOfJoinery > 40)
    {
        finalPrice *= 0.94;
    }

    finalPrice *= countOfJoinery;
}
else if (typeOfJoinery == "130X180")
{
    finalPrice = 190;

    if (countOfJoinery > 50)
    {
        finalPrice *= 0.88;
    }
    else if (countOfJoinery > 20)
    {
        finalPrice *= 0.93;
    }

    finalPrice *= countOfJoinery;
}
else if (typeOfJoinery == "200X300")
{
    finalPrice = 250;

    if (countOfJoinery > 50)
    {
        finalPrice *= 0.86;
    }
    else if (countOfJoinery > 25)
    {
        finalPrice *= 0.91;
    }

    finalPrice *= countOfJoinery;
}


if (delivery == "With delivery")
{
    finalPrice += 60;
}

if (countOfJoinery > 99)
{
    finalPrice *= 0.96;
}

if (!invalidOrder)
{
    Console.WriteLine($"{finalPrice:F2} BGN");
}