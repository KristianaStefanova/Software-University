string city = Console.ReadLine();
string typeOfPacket = Console.ReadLine();
string VIPDiscount = Console.ReadLine();
int countOfDays = int.Parse(Console.ReadLine());
bool inValidInput = false;
bool validInput = false;
bool positiveNumber = true;

double finalPrice = 0.0;


if ((city == "Bansko" || city == "Borovets" || city == "Varna" || city == "Burgas") && (typeOfPacket == "noEquipment"|| typeOfPacket == "withEquipment" || typeOfPacket == "noBreakfast" || typeOfPacket == "withBreakfast"))
{
    validInput = true;
}

if (validInput == false)
{
    inValidInput = true;
    Console.WriteLine("Invalid input!");

}

if (countOfDays == 0)
{
    Console.WriteLine("Days must be positive number!");
    positiveNumber = false;
}

if (city == "Bansko" || city == "Borovets")
{


    if (typeOfPacket == "noEquipment" && positiveNumber != false)
    {
        if (countOfDays > 7)
        {
            finalPrice += 80 * countOfDays - 1;

        }
        finalPrice += 80 * countOfDays;

        if (VIPDiscount == "yes")
        {

            finalPrice *= 0.95;
        }

    }
    else if (typeOfPacket == "withEquipment" && positiveNumber != false)
    {
        if (countOfDays > 7)
        {
            finalPrice += 80 * countOfDays - 1;
        }
        finalPrice += 100 * countOfDays;

        if (VIPDiscount == "yes")
        {
            finalPrice *= 0.9;
        }

    }
}
else if (city == "Varna" || city == "Burgas")
{
    if (typeOfPacket == "noBreakfast" && positiveNumber != false)
    {
        if (countOfDays > 7)
        {
            finalPrice += 80 * countOfDays - 1;
        }
        finalPrice += 100 * countOfDays;

        if (VIPDiscount == "yes")
        {
            finalPrice *= 0.93;
        }
    }
    else if (typeOfPacket == "withBreakfast" && positiveNumber != false)
    {
        
        if (countOfDays > 7)
        {
            finalPrice += 80 * countOfDays - 1;
        }
        finalPrice += 130 * countOfDays;

        if (VIPDiscount == "yes")
        {
            finalPrice *= 0.88;
        }
    }
}

if (inValidInput == false && positiveNumber != false)
{
    Console.WriteLine($"The price is {finalPrice:F2}lv! Have a nice time!");

}




