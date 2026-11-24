double rent = double.Parse(Console.ReadLine());

double cake = rent * 0.2;
double drinks = cake - (cake * 0.45);
double aninmator = rent / 3;

double finalPrice = rent + cake + drinks + aninmator;

Console.WriteLine($"{finalPrice:F1}");