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

            var grades = context.Grades.Include(x=>x.Students).ToList();

            //var students = context.Students.ToList();// .Where(s => s.Name == "aaa");

            //var studentWithGrade = context.Students
            //                        .Where(s => s.Name == "aaa")
            //                        .Include(s => s.Grade)
            //                        .FirstOrDefault();

            Console.ReadLine();
        }
    }
}
