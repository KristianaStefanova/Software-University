namespace _04.Students
{
    internal class Program
    {
        static void Main()
        {
            int countOfStudents = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < countOfStudents; i++)
            {
                string[] propStudent = Console.ReadLine()
                    .Split();

                Student student = new Student(propStudent[0], propStudent[1], float.Parse(propStudent[2]));

                students.Add(student);
            }

            students = students.OrderByDescending(x => x.Grade).ToList();

            Console.WriteLine(string.Join("\n", students));
        }

        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public float Grade { get; set; }

            public Student(string firstName, string lastName, float grade)
            {
                FirstName = firstName;
                LastName = lastName;
                Grade = grade;
            }

            public override string ToString()
            {
                return $"{FirstName} {LastName}: {Grade:F2}";
            }
        }
    }
}
