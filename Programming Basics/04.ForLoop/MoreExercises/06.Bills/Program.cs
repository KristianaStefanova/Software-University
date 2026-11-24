int months = int.Parse(Console.ReadLine());

double sumBill = 0.0;
double water = 0;
double internet = 0;
double sumElecticity = 0.0;
double others = 0.0;

for (int i = 0; i < months; i++)
{
    double electicity = double.Parse(Console.ReadLine());

    sumElecticity += electicity;
    water += 20;
    internet += 15;
}

others = (sumElecticity + water + internet) * 1.20;
sumBill = others + sumElecticity + water + internet;

double averageBillPerMonth = sumBill / months;

Console.WriteLine($"Electricity: {sumElecticity:F2} lv");
Console.WriteLine($"Water: {water:F2} lv");
Console.WriteLine($"Internet: {internet:F2} lv");
Console.WriteLine($"Other: {others:F2} lv");
Console.WriteLine($"Average: {averageBillPerMonth:F2} lv");
