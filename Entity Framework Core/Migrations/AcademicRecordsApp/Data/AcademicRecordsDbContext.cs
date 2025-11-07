using AcademicRecordsApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademicRecordsApp.Data
{
    public partial class AcademicRecordsDbContext : DbContext
    {
        public AcademicRecordsDbContext()
        {
        }

        public AcademicRecordsDbContext(DbContextOptions<AcademicRecordsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Exam> Exams { get; set; } = null!;

        public virtual DbSet<Grade> Grades { get; set; } = null!;

        public virtual DbSet<Student> Students { get; set; } = null!;

        public virtual DbSet<Course> Courses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.GetConnectionString());
            }
        }
            

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>(entity =>
            {
                entity
                    .HasKey(e => e.Id)
                    .HasName("PK__Exams__3214EC07FB7FC394");

                entity
                    .Property(e => e.Name)
                    .HasMaxLength(100);

                entity
                    .HasOne(e => e.Course)
                    .WithMany(c => c.Exams)
                    .HasForeignKey(e => e.CourseId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity
                    .HasKey(e => e.Id)
                    .HasName("PK__Grades__3214EC07EBEE937F");

                entity
                    .Property(e => e.Value)
                    .HasColumnType("decimal(3, 2)");

                entity
                    .HasOne(d => d.Exam)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grades_Exams");

                entity
                    .HasOne(d => d.Student)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grades_Students");

            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity
                    .HasKey(e => e.Id)
                    .HasName("PK__Students__3214EC072951F6D9");

                entity
                    .Property(e => e.FullName)
                    .HasMaxLength(100);

                entity
                    .HasMany(e => e.Courses)
                    .WithMany(e => e.Students)
                    .UsingEntity<Dictionary<string, object>>(
                        "StudentsCourses",
                           r => r
                        .HasOne<Course>()
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                           l => l
                        .HasOne<Student>()
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    me =>
                    {
                        me.HasKey("StudentId", "CourseId");
                        me.ToTable("StudentsCourses");
                    });
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity
                    .HasKey(c => c.Id);

                entity
                    .Property(c => c.Name)
                    .HasMaxLength(100);

                entity  
                    .Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsRequired(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
