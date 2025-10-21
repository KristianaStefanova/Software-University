﻿using System.ComponentModel.DataAnnotations;

namespace MiniORM.TestApp.Models
{
    public class Project
    {
        public Project()
        {
            this.EmployeesProjects = new HashSet<EmployeeProject>();
        }

        [Key]
        public int ProjectID { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual ICollection<EmployeeProject> EmployeesProjects { get; set; }
    }
}
