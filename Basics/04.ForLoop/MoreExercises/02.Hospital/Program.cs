int period = int.Parse(Console.ReadLine());

int treatedPatients = 0;
int noTreatedPatients = 0;
int numOfDoctors = 7;
int day = 0;

for (int i = 0; i < period; i++)
{
    int patientsPerDay = int.Parse(Console.ReadLine());
    day++;
    if (day % 3 == 0)
    {
        if (treatedPatients < noTreatedPatients)
        {
            numOfDoctors++;
        }
    }

    if (patientsPerDay > numOfDoctors)
    {
        noTreatedPatients += patientsPerDay - numOfDoctors;
        treatedPatients += numOfDoctors;
    }
    else if (patientsPerDay <= numOfDoctors)
    {
        treatedPatients += patientsPerDay;
    }

}
Console.WriteLine($"Treated patients: {treatedPatients}.");
Console.WriteLine($"Untreated patients: {noTreatedPatients}.");
