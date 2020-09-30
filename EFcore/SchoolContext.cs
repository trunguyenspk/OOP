using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFcore
{
    public class SchoolContext : DbContext
    {
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=SchoolDB;Trusted_Connection=True;");
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
        public string Name { get; set; }
        
        public Grade Grade { get; set; }

        // This ensures that the value of the foreign key column StudentId must be unique in the StudentAddress table, 
        // which is necessary of a one-to-one relationship
        public StudentAddress Address { get; set; }
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
    }
}
