

int countOfBitcoins = int.Parse(Console.ReadLine());    
double countOfChaniesYouan = double.Parse(Console.ReadLine());
double commission = double.Parse(Console.ReadLine());

int bitcoinInLeva = countOfBitcoins * 1168;

double chaniesYouanesInDolars = countOfChaniesYouan * 0.15;
double youanesInLeva = chaniesYouanesInDolars * 1.76;

double totalPriceInLeva = youanesInLeva + bitcoinInLeva;
double totalPriceInEuro = totalPriceInLeva / 1.95;


double finalMoneyWhitCommission = totalPriceInEuro - (totalPriceInEuro * commission / 100);

Console.WriteLine($"{finalMoneyWhitCommission:F2}");