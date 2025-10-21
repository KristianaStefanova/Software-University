﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniORM.TestApp.Models
{
    public class Department
    {
        public Department()
        {
            this.Employees = new HashSet<Employee>();
        }

        [Key]
        public int DepartmentID { get; set; }

        public string Name { get; set; } = null!;

        [ForeignKey(nameof(Manager))]
        public int ManagerID { get; set; }

        public virtual Employee Manager { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
