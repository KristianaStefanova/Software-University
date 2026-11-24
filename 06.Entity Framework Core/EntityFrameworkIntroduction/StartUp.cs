using SoftUni.Data;
using SoftUni.Models;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SoftUniContext context = new SoftUniContext();

            // Problem 3 - Employees Full Information
            Console.WriteLine(GetEmployeesFullInformation(context));

            // Problem 4 - Employees with Salary Over 50 000
            Console.WriteLine(GetEmployeesWithSalaryOver50000(context));

            // Problem 5 - Employees from Research and Development
            Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));

            // Problem 6 - Adding a New Address and Updating Employee
            Console.WriteLine(AddNewAddressToEmployee(context));

            // Problem 7 - Employees and Projects
            Console.WriteLine(GetEmployeesInPeriod(context));

            // Problem 8 - Addresses by Town
            Console.WriteLine(GetAddressesByTown(context));

            // Problem 9 - Employee 147
            Console.WriteLine(GetEmployee147(context));

            // Problem 10 - Departments with More Than 5 Employees
            Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));

            // Problem 11 - Find Latest 10 Projects
            Console.WriteLine(GetLatestProjects(context));

            // Problem 12 - Increase Salaries
            Console.WriteLine(IncreaseSalaries(context));

            // Problem 13 - Find Employees by First Name Starting With Sa
            Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));

            // Problem 14 - Delete Project by Id
            Console.WriteLine(DeleteProjectById(context));

            // Task 15 - Remove Town
            Console.WriteLine(RemoveTown(context));
        }

        // Problem 3
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();

        }

        // Problem 4
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 5
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}");

            }

            return sb.ToString().TrimEnd();
        }

        // Problem 6
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Employee nakovEmployee = context
                .Employees
                .First(e => e.LastName == "Nakov");
            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            nakovEmployee.Address = newAddress;

            context.SaveChanges();

            string[] employeesAddresses = context
                .Employees
                .OrderByDescending(e => e.Address.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToArray();

            return string.Join(Environment.NewLine, employeesAddresses);
        }

        // Problem 7
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName
                })
                .Take(10)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                var employeeProjects = context
                    .EmployeesProjects
                    .Where(ep => ep.EmployeeId == employee.EmployeeId &&
                           ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                    .Select(ep => new
                    {
                        ep.EmployeeId,
                        ep.Project
                    })
                    .ToList();

                foreach (var project in employeeProjects)
                {
                    if (project.Project.EndDate == null)
                    {
                        sb.AppendLine($"--{project.Project.Name} - {project.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt")} - not finished");
                    }
                    else
                    {
                        sb.AppendLine($"--{project.Project.Name} - {project.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt")} - {project.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt")}");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 8
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var addresses = context
                .Addresses
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeesCount = a.Employees.Count
                })
                .OrderByDescending(a => a.EmployeesCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 9
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee147 = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                })
                .FirstOrDefault();

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            var employeeProjects = context
                .EmployeesProjects
                .Where(ep => ep.EmployeeId == 147)
                .Select(ep => new
                {
                    ep.Project.Name
                })
                .OrderBy(p => p.Name)
                .ToList();

            foreach (var project in employeeProjects)
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().TrimEnd();


        }

        // Problem 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var depMoreThan5Employees = context
                .Departments
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Where(d => d.Employees.Count > 5)
                .Select(d => new
                {
                    d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    d.Employees
                })
                .ToList();

            foreach (var departemnt in depMoreThan5Employees)
            {
                sb.AppendLine($"{departemnt.Name} – {departemnt.ManagerFirstName} {departemnt.ManagerFirstName}");


                foreach (var employee in departemnt.Employees
                                                   .OrderBy(e => e.FirstName)
                                                   .ThenBy(e => e.LastName))
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();

        }

        // Problem 11
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            Project[] latestProjects = context
                .Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .ToArray();

            foreach (var project in latestProjects)
            {
                sb.AppendLine($"{project.Name}{Environment.NewLine}{project.Description}{Environment.NewLine}{project.StartDate.ToString("M/d/yyyy h:mm:ss tt")}");
            }

            return sb.ToString().TrimEnd();

        }

        // Problem 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesToIncrease = context
                .Employees
                .Where(e => e.Department.Name == "Engineering" ||
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services")
                .ToArray();

            foreach (var employee in employeesToIncrease.OrderBy(e => e.FirstName)
                                                        .ThenBy(e => e.LastName))
            {
                employee.Salary *= 1.12m;

                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var emplNameStartingWithSa = context
                .Employees
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .ToArray();

            foreach (var employee in emplNameStartingWithSa)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 14
        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectsReferencedToRemove = context
                .EmployeesProjects
                .Where(ep => ep.ProjectId == 2);

            foreach (var project in projectsReferencedToRemove)
            {
                context.EmployeesProjects.RemoveRange(project);
            }

            var projects = context
                .Projects
                .Where(ep => ep.ProjectId == 2);

            foreach (Project project in projects)
            {
                context.Projects.RemoveRange(project);
            }

            context.SaveChanges();

            var projectsToPrint = context
                .Projects
                .Select(p => p.Name)
                .Take(10);

            return string.Join(Environment.NewLine, projectsToPrint);
        }

        // Problem 15
        public static string RemoveTown(SoftUniContext context)
        {
            var employeesToChangeAddress = context
               .Employees
               .Where(e => e.Address.Town.Name == "Seattle");
            foreach (var employee in employeesToChangeAddress)
            {
                employee.AddressId = null;
                employee.Address = null;
            }

            int countOfDeletedAddresses = 0;

            var addressesToRemove = context
                .Addresses
                .Where(a => a.Town.Name == "Seattle");
            foreach (var address in addressesToRemove)
            {
                countOfDeletedAddresses++;
                context.Addresses.RemoveRange(address);
            }

            var townToRemove = context
                .Towns
                .FirstOrDefault(t => t.Name == "Seattle");
            if (townToRemove != null)
            {
                context.Towns.RemoveRange(townToRemove);
            }

            context.SaveChanges();

            return $"{countOfDeletedAddresses} addresses in Seattle were deleted";
        }
    }
}
