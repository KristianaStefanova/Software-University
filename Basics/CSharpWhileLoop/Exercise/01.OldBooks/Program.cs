string nameBook = Console.ReadLine();
int counter = 0;
string currentBook = Console.ReadLine();

while (currentBook != "No More Books")
{
    if (currentBook == nameBook)
    {
        break;
    }
    counter++;
    currentBook = Console.ReadLine(); 
}
if (currentBook == nameBook)
{
    Console.WriteLine($"You checked {counter} books and found it.");
}
else
{
    Console.WriteLine("The book you search is not here!");
    Console.WriteLine($"You checked {counter} books.");
}
