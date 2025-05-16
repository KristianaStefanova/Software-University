int lenght = int.Parse(Console.ReadLine());
int widgh = int.Parse(Console.ReadLine());
int height = int.Parse(Console.ReadLine());
double percent = double.Parse(Console.ReadLine());

 //Calculation

double volume = lenght * widgh * height / 1000.0;
double finalLitters = volume * (1 - percent / 100);
 

Console.WriteLine(finalLitters);



