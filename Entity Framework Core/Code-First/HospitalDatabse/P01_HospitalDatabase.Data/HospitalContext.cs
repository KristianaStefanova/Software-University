using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;
using System.ComponentModel.DataAnnotations;
using static P01_HospitalDatabase.Common.ApplicationConstants;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
            
        }

        public HospitalContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public virtual DbSet<Patient> Patients { get; set; } = null!;

        public virtual DbSet<Visitation> Visitations { get; set; } = null!;

        public virtual DbSet<Diagnose> Diagnoses { get; set; } = null!;

        public virtual DbSet<Medicament> Medicaments { get; set; } = null!;

        public virtual DbSet<PatientMedicament> PatientsMedicaments { get; set; } = null!;

        public virtual DbSet<Doctor> Doctors { get; set; } = null!;



        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        override protected void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PatientMedicament>(e =>
            {
                e.HasKey(pm => new { pm.PatientId, pm.MedicamentId });
            });

            base.OnModelCreating(builder);
        }
    }
}
