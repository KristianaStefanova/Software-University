class Program
{
    static void Main()
    {
        Dictionary<string, Course> coursesMap = new Dictionary<string, Course>();

        string command;

        while ((command = Console.ReadLine()) != "end")
        {
            string[] arguments = command.Split(" : ");
            string courseName = arguments[0];
            string studentName = arguments[1];

            Course course = new(courseName);

            if (!coursesMap.ContainsKey(courseName))
            {
                coursesMap.Add(courseName, course);
            }

            coursesMap[courseName].Student.Add(studentName);
        }

        foreach (KeyValuePair<string, Course> pair in coursesMap)
        {
            Console.WriteLine(pair.Value);
        }
    }
}

class Course
{
    public Course(string courseName)
    {
        Name = courseName;
        Student = new List<string>();
    }
    public string Name { get; set; }

    public List<string> Student { get; set; }

    public override string ToString()
    {
        string result = $"{Name}: {Student.Count}\n";

        for (int i = 0; i < Student.Count; i++)
        {
            result += $"-- {Student[i]}\n";
        }

        return result.Trim();
    }
}

