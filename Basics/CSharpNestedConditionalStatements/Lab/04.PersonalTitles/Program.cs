﻿double age = double.Parse(Console.ReadLine());
char gender = char.Parse(Console.ReadLine());


if (gender == 'f')
{
    if (age < 16)
    {
        Console.WriteLine("Miss");
    }
    else
    {
        Console.WriteLine("Ms.");
    }
}

if (gender == 'm')
{
    if (age < 16)
    {
        Console.WriteLine("Master");
    }
    else
    {
        Console.WriteLine("Mr.");
    }


}









   