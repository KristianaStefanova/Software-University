int rent = int.Parse(Console.ReadLine());

double statued = rent - (rent * 0.3);
double catering = statued - (statued * 0.15);
double sound = catering / 2;
double finalPrice = rent + statued + catering + sound;

Console.WriteLine($"{finalPrice:F2}");