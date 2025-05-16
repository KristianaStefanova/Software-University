
class Program
{ 
    static void Main()
    {
        string studentName = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());    
        double averigeGrade = double.Parse(Console.ReadLine()); 

        Console.WriteLine($"Name: {studentName}, Age: {age}, Grade: {averigeGrade:F2}");
    }
}
