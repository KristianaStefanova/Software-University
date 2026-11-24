int volume = int.Parse(Console.ReadLine());
int pipe1 = int.Parse(Console.ReadLine());
int pipe2 = int.Parse(Console.ReadLine());
double time = double.Parse(Console.ReadLine());

double water = (pipe1 + pipe2) * time;

if (volume >= water)
{
    double percentFull = Math.Truncate(water / volume * 100);
    double percentPipe1 = Math.Truncate(pipe1 * time / water * 100);
    double percentPipe2 = Math.Truncate(pipe2 * time / water * 100);

    Console.WriteLine($"The pool is {percentFull:F2} % full.Pipe 1: {percentPipe1:F2} %.Pipe2: {percentPipe2:F2} %.");
}
else if (volume < water)
{
    double waterLeft = water - volume;
    Console.WriteLine($"For {time} hours the pool overflows with {waterLeft} liters.");
}
