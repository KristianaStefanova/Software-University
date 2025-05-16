double lengthPark = double.Parse(Console.ReadLine());
double widthTile = double.Parse(Console.ReadLine());
double lengthTile = double.Parse(Console.ReadLine());
double widthBench = double.Parse(Console.ReadLine());
double lenghthBench = double.Parse(Console.ReadLine());

double sizePark = lengthPark * lengthPark;

double sizeBench = widthBench * lenghthBench;
double sizeTile = widthTile * lengthTile;
double areaTile = sizePark - sizeBench;

double numOfTile = areaTile / sizeTile;
double timeNeeded = numOfTile * 0.2;
Console.WriteLine(numOfTile);
Console.WriteLine(timeNeeded);