using System.Globalization;

class Program
{
    static void Main()
    {
        int countOfPeople = int.Parse(Console.ReadLine());
        string typeOfGroup = Console.ReadLine();
        string day = Console.ReadLine();
        double finalPrice = 0.0;
        bool withDiscount = false;

        if (typeOfGroup == "Students")
        {
            switch (day)
            {
                case "Friday":
                    finalPrice = 8.45;
                    break;
                case "Saturday":
                    finalPrice = 9.80;
                    break;
                case "Sunday":
                    finalPrice = 10.46;
                    break;
                
            }
        }
        else if (typeOfGroup == "Business")
        {
            switch (day)
            {
                case "Friday":
                    finalPrice = 10.90;
                    break;
                case "Saturday":
                    finalPrice = 15.60;
                    break;
                case "Sunday":
                    finalPrice = 16;
                    break;

            }
        }
        else if (typeOfGroup == "Regular")
        {
            switch (day)
            {
                case "Friday":
                    finalPrice = 15;
                    break;
                case "Saturday":
                    finalPrice = 20;
                    break;
                case "Sunday":
                    finalPrice = 22.50;
                    break;

            }
        }
        if (typeOfGroup == "Students" && countOfPeople >= 30)
        {
            withDiscount = true;
            finalPrice *= countOfPeople;
            finalPrice *= 0.85;
        }
        else if (typeOfGroup == "Business" && countOfPeople >= 100)
        {
            withDiscount = true;
            countOfPeople -= 10;
            finalPrice *= countOfPeople;
        }
        else if (typeOfGroup == "Regular" && (countOfPeople >= 10 && countOfPeople <= 20))
        {
            withDiscount = true;
            finalPrice *= 0.95; ;
        }
        if (!withDiscount)
        {
            finalPrice *= countOfPeople;
        Console.WriteLine($"Total price: {finalPrice:F2}");
        }
        else 
        {
            Console.WriteLine($"Total price: {finalPrice:F2}");
        }
    }
}

