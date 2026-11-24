int dayWorkPerMonth = int.Parse(Console.ReadLine());
double moneyPerDay = double.Parse(Console.ReadLine());
double courseDolerToLeva = double.Parse(Console.ReadLine());

double moneyPerMonth = dayWorkPerMonth * moneyPerDay;
double moneyPerYear = moneyPerMonth * 12;
double bonusPerYear = moneyPerMonth * 2.5;
double totalMoneyPerYear = moneyPerYear + bonusPerYear;
double moneyWithIva = totalMoneyPerYear - (totalMoneyPerYear * 0.25);

double moneyInLeva = moneyWithIva * courseDolerToLeva;

double finalMoneyPerDay = moneyInLeva / 365;

Console.WriteLine($"{finalMoneyPerDay:F2}");

