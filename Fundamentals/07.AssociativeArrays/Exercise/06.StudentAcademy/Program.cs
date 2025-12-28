class Program
{
    static void Main()
    {

        Dictionary<string, Student> studentMap = new Dictionary<string, Student>();
        int countOfStudents = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfStudents; i++)
        {
            string name = Console.ReadLine();
            double grade = double.Parse(Console.ReadLine());

            if (!studentMap.ContainsKey(name))
            {
                Student student = new Student(name);
                studentMap[name] = student;
            }

            studentMap[name].Grades.Add(grade);
        }

        foreach (Student student in studentMap.Values)
        {
            double average = student.Average();

            if (average >= 4.50)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}

class Student
{
    public Student(string name)
    {
        Grades = new List<double>();
        Name = name;
    }
    public string Name { get; set; }
    public List<double> Grades { get; set; }
    public override string ToString()
    {
        return $"{Name} -> {Average():F2}";
    }

    public double Average()
    {
        double sum = 0;
        foreach (double grade in Grades)
        {
            sum += grade;
        }

        return sum / Grades.Count;
    }
}

