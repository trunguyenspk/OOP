using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFcore
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SchoolContext();

            var grades = context.Grades.ToList();

            //var students = context.Students.ToList();// .Where(s => s.Name == "aaa");

            var students = context.Students.FromSqlRaw("GetStudents '1'").ToList();

            var rowsAffected = context.Database.ExecuteSqlRaw("insert into Students(StudentName, GradeId_FK) values('StudentName',1) ;");

            Console.ReadLine();
        }
    }
}
