/*
 •	Lightsaber 10% more, Math.Ceiling, 6th belt is free
•	Belt
•	Robe
 
 
 */
class Program
{
    static void Main()
    {
        double amount = double.Parse(Console.ReadLine());   
        int countOfStudents = int.Parse(Console.ReadLine());
        double priceLightsaber = double.Parse(Console.ReadLine());
        double priceRobe = double.Parse(Console.ReadLine());
        double priceBelt = double.Parse(Console.ReadLine());

        double totalPrice = 0.0;

        double sabersExtra = (double)countOfStudents * 10 / 100;
        double countOfSabres = countOfStudents + Math.Ceiling(sabersExtra);
        double freeBels = countOfStudents / 6;
        double countOfBelts = countOfStudents - freeBels;
        totalPrice = Math.Round(countOfSabres * priceLightsaber + countOfStudents * priceRobe + countOfBelts * priceBelt, 2);

        if (totalPrice <= amount)
        {
            Console.WriteLine($"The money is enough - it would cost {totalPrice:F2}lv.");
        }
        else
        {
            double neededMoney = totalPrice - amount;
            Console.WriteLine($"John will need {neededMoney:F2}lv more.");
        }
    }
}

