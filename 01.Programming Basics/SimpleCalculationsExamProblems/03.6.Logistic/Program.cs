int countOfPackets = int.Parse(Console.ReadLine());
int totalTons = 0;
int counterMicrobus = 0;
int priceMicrobus = 0;
int counterTruck = 0;
int priceTruck = 0;
int counterTrain = 0;
int priceTrain = 0;

for (int i = 0; i < countOfPackets; i++)
{
    int tonesPerPacket = int.Parse(Console.ReadLine());
    totalTons += tonesPerPacket;

    if (tonesPerPacket <= 3)
    {
        counterMicrobus+= tonesPerPacket;
        priceMicrobus += 200 * tonesPerPacket;
    }
    else if (tonesPerPacket > 3 && tonesPerPacket <=11)
    {
        counterTruck += tonesPerPacket; ;
        priceTruck += 175 * tonesPerPacket;
    }
    else
    {
        counterTrain+=tonesPerPacket;
        priceTrain += 120 * tonesPerPacket;
    }
}
double totalPrice = priceMicrobus + priceTruck + priceTrain;
double avaragePricePer1Tone = totalPrice / totalTons;

Console.WriteLine($"{avaragePricePer1Tone:F2}");

double percentMicrobus = (double)counterMicrobus / totalTons * 100;
Console.WriteLine($"{percentMicrobus:F2}%");

double percentTruck = (double)counterTruck / totalTons * 100;
Console.WriteLine($"{percentTruck:F2}%");

double percentTrain = (double)counterTrain / totalTons * 100;
Console.WriteLine($"{percentTrain:F2}%");