class Program
{
    static void Main()
    {
        string[] listOfVehicles = Console.ReadLine()
            .Split(">>");

        int totalTaxCalected = 0;

        for (int i = 0; i < listOfVehicles.Length; i++)
        {
            string[] currentVehicle = listOfVehicles[i].Split();

            string type = currentVehicle[0];
            int years = int.Parse(currentVehicle[1]);
            int kilometers = int.Parse(currentVehicle[2]);

            int initialTax = 0;
            int taxDeclines = 0;
            int taxInreases = 0;
            int totalTaxToPay = 0;
            switch (type)
            {
                case "family":
                    initialTax = 50;
                    taxDeclines = 5;
                    taxInreases = 12;
                    totalTaxToPay = initialTax - (years * taxDeclines) + (kilometers / 3000) * taxInreases;
                    break;

                case "heavyDuty":
                    initialTax = 80;
                    taxDeclines = 8;
                    taxInreases = 14;
                    totalTaxToPay = initialTax - (years * taxDeclines) + (kilometers / 9000) * taxInreases;
                    break;

                case "sports":
                    initialTax = 100;
                    taxDeclines = 9;
                    taxInreases = 18;
                    totalTaxToPay = initialTax - (years * taxDeclines) + (kilometers / 2000) * taxInreases;
                    break;

                default:
                    Console.WriteLine("Invalid car type.");
                    continue;
                    break;
            }

            Console.WriteLine($"A {type} car will pay {totalTaxToPay:F2} euros in taxes.");

            totalTaxCalected += totalTaxToPay;
        }

        Console.WriteLine($"The National Revenue Agency will collect {totalTaxCalected:F2} euros in taxes.");
    }
}

