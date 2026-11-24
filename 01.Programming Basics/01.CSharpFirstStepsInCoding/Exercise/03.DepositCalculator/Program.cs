//сума = депозирана сума  + срок на депозита * ((депозирана сума * годишен лихвен процент ) / 12)

double deposit = double.Parse(Console.ReadLine());
int periodOfDeposit = int.Parse(Console.ReadLine());
double profitPercentPerYear = double.Parse(Console.ReadLine());

double yearProfit = deposit * (profitPercentPerYear / 100);
double monthProfit = yearProfit / 12;
double finalProfit = deposit + periodOfDeposit * monthProfit;

Console.WriteLine(finalProfit);
