class Program
{
    static void Main()
    {
        Dictionary<string, Employee> employeesMap = new Dictionary<string, Employee>();

        string command;

        while ((command = Console.ReadLine()) != "End")
        {
            string[] arguments = command.Split(" -> ");
            string nameCompany = arguments[0];
            string id = arguments[1];

            if (!employeesMap.ContainsKey(nameCompany))
            {
                Employee employee = new(nameCompany);
                employeesMap[nameCompany] = employee;
            }

            employeesMap[nameCompany].AddEmployee(id);
        }

        foreach (KeyValuePair<string, Employee> pair in employeesMap)
        {
            Console.WriteLine(pair.Value);
        }
    }
}

class Employee
{
    public Employee(string nameCompany)
    {
        NameCompany = nameCompany;
        Id = new List<string>();
    }
    public string NameCompany { get; set; }
    public List<string> Id { get; set; }
    public override string ToString()
    {
        string result = $"{NameCompany}\n";

        foreach (string id in Id)
        {
            result += $"-- {id}\n";
        }

        return result.Trim();
    }

    public void AddEmployee(string id)
    {
        if (!Id.Contains(id))
        {
            Id.Add(id);
        }
    }
}

