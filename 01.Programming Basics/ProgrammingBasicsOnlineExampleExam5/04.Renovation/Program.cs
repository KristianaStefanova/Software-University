int length = int.Parse(Console.ReadLine());
int width = int.Parse(Console.ReadLine());
int percentWihoutPainting = int.Parse(Console.ReadLine());

double totalAreaPainted = 0;
int totalLitterPainting = 0;

int areaWalls = length * width * 4;
double areaWithoutPainting = (areaWalls * percentWihoutPainting / 100);
double areaToBePaint = Math.Ceiling(areaWalls - areaWithoutPainting);

while (totalAreaPainted < areaToBePaint)
{
    string input = Console.ReadLine();

    if (input == "Tired!")
    {
        double areaLeft = areaToBePaint - (int)totalAreaPainted;

        Console.WriteLine($"{areaLeft} quadratic m left.");
        break;
    }
    int litterPainting = int.Parse(input);

    totalAreaPainted += litterPainting;
    totalLitterPainting += litterPainting;
}

if (totalAreaPainted >= areaToBePaint)
{
    if (totalLitterPainting == areaToBePaint)
    {
        Console.WriteLine("All walls are painted! Great job, Pesho!");
    }
    else
    {
        int littersPaintLeft = totalLitterPainting - (int)areaToBePaint;
        Console.WriteLine($"All walls are painted and you have {littersPaintLeft} l paint left!");
    }
}

