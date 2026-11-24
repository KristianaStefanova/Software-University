int bitcoins = int.Parse(Console.ReadLine());
double ioana = double.Parse(Console.ReadLine());
double commission = double.Parse(Console.ReadLine());

double bitcoinInLeva = bitcoins * 1168;
double ioanaInLeva = ioana * 0.15 * 1.76;

double finalSumInLeva = bitcoinInLeva + ioanaInLeva;
double finalSumInEuro = finalSumInLeva / 1.95;
commission = finalSumInEuro * 0.05;

Console.WriteLine(finalSumInEuro - commission);
