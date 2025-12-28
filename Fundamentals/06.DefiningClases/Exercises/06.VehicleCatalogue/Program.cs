
using System.Diagnostics.Metrics;

namespace _06.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> catalogue = new List<Vehicle>();


            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command.Split();
                string type = arguments[0];
                string model = arguments[1];
                string color = arguments[2];
                decimal hp = decimal.Parse(arguments[3]);

                Vehicle vehicle = new(type, model, color, hp);
                catalogue.Add(vehicle);
            }


            while ((command = Console.ReadLine()) != "Close the Catalogue")
            {
                string modelOfVehicle = command;

                foreach (Vehicle vehicle in catalogue)
                {
                    if (vehicle.Model == modelOfVehicle)
                    {
                        Console.WriteLine(vehicle.ToString());
                    }
                }
            }

            PrintAverageSum(catalogue, "Car");
            PrintAverageSum(catalogue, "Truck");
        }

        private static void PrintAverageSum(List<Vehicle> catalogue, string typeOfVehicle)
        {
            decimal sum = 0.0m;
            int counter = 0;
            foreach (Vehicle vehicle in catalogue)
            {
                if (vehicle.Type == typeOfVehicle)
                {
                    counter++;
                    sum += vehicle.HP;
                }
            }
            decimal average = counter > 0 ? sum / counter : 0;

            Console.WriteLine($"{typeOfVehicle}s have average horsepower of: {average:F2}.");
        }
    }

    class Vehicle
    {
        public Vehicle(string type, string model, string color, decimal hp)
        {
            Type = char.ToUpper(type[0]) + type.Substring(1);       // == "car" ? "Car" : "Truck";
            Model = model;
            Color = color;
            HP = hp;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public decimal HP { get; set; }

        public override string ToString()
        {
            return $"Type: {Type}\n" +
                   $"Model: {Model}\n" +
                   $"Color: {Color}\n" +
                   $"Horsepower: {HP}";
        }
    }
}
