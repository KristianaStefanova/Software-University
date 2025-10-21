﻿using MiniORM.TestApp.Models;

namespace MiniORM.TestApp
{
    public class SoftUniDbContext : DbContext
    {
        public SoftUniDbContext(string connectionString)
            : base(connectionString)
        {

        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeProject> EmployeesProjects { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Town> Towns { get; set; }
    }
}