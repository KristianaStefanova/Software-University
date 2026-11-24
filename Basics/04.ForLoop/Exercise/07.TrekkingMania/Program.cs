int numOfgroups = int.Parse(Console.ReadLine());

int counterMusala = 0;
int counterMonblan = 0;
int counterKalimandjaro = 0;
int counterK2 = 0;
int counterEverest = 0;


for (int i = 0; i < numOfgroups; i++)
{
    int numberOfPeoplePerGropup = int.Parse(Console.ReadLine());
    if (numberOfPeoplePerGropup <= 5)
    {
        counterMusala += numberOfPeoplePerGropup;
    }
    else if (numberOfPeoplePerGropup >= 6 && numberOfPeoplePerGropup <= 12)
    {
        counterMonblan += numberOfPeoplePerGropup;
    }
    else if (numberOfPeoplePerGropup >= 13 && numberOfPeoplePerGropup <= 25)
    {
        counterKalimandjaro += numberOfPeoplePerGropup;
    }
    else if (numberOfPeoplePerGropup >= 26 && numberOfPeoplePerGropup <= 40)
    {
        counterK2 += numberOfPeoplePerGropup;
    }
    else if (numberOfPeoplePerGropup >= 41)
    {
        counterEverest += numberOfPeoplePerGropup;
    }
}
int allPeople = counterMusala + counterMonblan + counterKalimandjaro + counterK2 + counterEverest;
double percentMusala = (double)counterMusala / (double)allPeople * 100;
double percentMonblan = (double)counterMonblan / (double)allPeople * 100;
double percentKalamandjaro = (double)counterKalimandjaro / (double)allPeople * 100;
double percentK2 = (double)counterK2 / (double)allPeople * 100;
double percentEverest = (double)counterEverest / (double)allPeople * 100;

Console.WriteLine($"{percentMusala:F2}%");
Console.WriteLine($"{percentMonblan:F2}%");
Console.WriteLine($"{percentKalamandjaro:F2}%");
Console.WriteLine($"{percentK2:F2}%");
Console.WriteLine($"{percentEverest:F2}%");