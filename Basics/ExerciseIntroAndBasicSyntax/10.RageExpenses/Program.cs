
class Program
{
    static void Main(string[] args)
    {
        int lostGames = int.Parse(Console.ReadLine());
        double priceHeadset = double.Parse(Console.ReadLine());
        double priceMouse = double.Parse(Console.ReadLine());
        double priceKeyboard = double.Parse(Console.ReadLine());
        double priceDisplay = double.Parse(Console.ReadLine());

        int counterHeadset = 0;
        int counterMouse = 0;
        int counterKeyboard = 0;
        int counterDisplay = 0;

        double finalPrice = 0.0;



        for (int day = 1; day <= lostGames; day ++)
        {

                if (day % 2 == 0)
                {
                    counterHeadset++;
                }
                if (day % 3 == 0)
                {
                    counterMouse++;
                }
                if (day % 6 == 0 )
                {
                    counterKeyboard++;
                }
                if (day % 6 == 0 && counterKeyboard % 2 == 0 && counterKeyboard > 0)
                {
                    counterDisplay++;
                }
            
        }


        finalPrice = counterHeadset * priceHeadset + counterMouse * priceMouse + counterKeyboard * priceKeyboard + counterDisplay * priceDisplay;
        Console.WriteLine($"Rage expenses: {finalPrice:F2} lv.");
    }

}






