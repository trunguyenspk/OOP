using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFcore
{
    public class SchoolContext : DbContext
    {
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }

        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => {
            builder.AddConsole();
        });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=localhost;Database=SchoolDB;Trusted_Connection=True;")
                .UseLoggerFactory(loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne<Student>(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne<Course>(sc => sc.Course)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);
        }
    }

    //public class SchoolDBInitializer : DropCreateDatabaseAlways<SchoolContext>
    //{
    //    protected override void Seed(SchoolContext context)
    //    {
    //        base.Seed(context);
    //    }
    //}

    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }

        public ICollection<Student> Students { get; set; }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public int GradeId_FK { get; set; }

        [ForeignKey("GradeId_FK")]
        public Grade Grade { get; set; }

        
        //FK key will take GradeId to make FK on Student if only use Principal entity
        //public Grade Grade { get; set; }


        // This ensures that the value of the foreign key column StudentId must be unique in the StudentAddress table, 
        // which is necessary of a one-to-one relationship
        public StudentAddress Address { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; }
    }

    public class StudentAddress
    {
        public int StudentAddressId { get; set; }
        public string Address { get; set; }
        
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; }
    }

    public class StudentCourse
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
