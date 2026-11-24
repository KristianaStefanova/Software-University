int volume = int.Parse(Console.ReadLine());
int pipe1 = int.Parse(Console.ReadLine());
int pipe2 = int.Parse(Console.ReadLine());
double hours = double.Parse(Console.ReadLine());

double volumeTwoPipes = (pipe1 + pipe2) * hours;
double totalPipe1 = pipe1 * hours;
double totalPipe2 = pipe2 * hours;

double percentPipe1 = totalPipe1 / volumeTwoPipes * 100;
double percentPipe2 = totalPipe2 / volumeTwoPipes * 100;
double percentFull = (double)volumeTwoPipes / volume * 100;

if (volumeTwoPipes <= volume)
{
    Console.WriteLine($"The pool is {percentFull:F2}% full. Pipe 1: {percentPipe1:F2}%. Pipe 2: {percentPipe2:F2}%.");
}
else
{
    double littersMore = volumeTwoPipes - volume;
    Console.WriteLine($"For {hours:F2} hours the pool overflows with {littersMore:F2} liters. ");
}