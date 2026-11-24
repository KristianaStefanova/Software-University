int period = int.Parse(Console.ReadLine());
int treatedPatients = 0;
int unTreatedPatients = 0;
int numOfDoctors = 7;

for (int day = 1; day <= period; day++)
{
    int patientsPerDay = int.Parse(Console.ReadLine());
    
    if (day % 3 == 0)
    {
        if (unTreatedPatients > treatedPatients)
        {
            numOfDoctors++;
        }
    }

    if (patientsPerDay >= numOfDoctors)
    {
        treatedPatients += numOfDoctors;
        unTreatedPatients += patientsPerDay - numOfDoctors;
    }
    else if (numOfDoctors > patientsPerDay)
   
    {
        treatedPatients += patientsPerDay;
    }
}
Console.WriteLine($"Treated patients: {treatedPatients}.");
Console.WriteLine($"Untreated patients: {unTreatedPatients}.");
