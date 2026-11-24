double length = double.Parse(Console.ReadLine());
double width = double.Parse(Console.ReadLine());

double lengthInSentimeters = length * 100;
double widthInSentimeters = width * 100;

double rowsWorkPlacesLength = (int)lengthInSentimeters / 120;
double rowsWorkPlacesWidth = ((int)widthInSentimeters - 100) / 70;

double countWorkPlaces = rowsWorkPlacesLength * rowsWorkPlacesWidth - 3;

Console.WriteLine(countWorkPlaces);