using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.EF_CodeFirst
{
    public static class SchoolContextRun
    {
        public static void Init()
        {
            using (var ctx = new SchoolContext())
            {
                var student = new Student() { StudentName = "Bill" };
                
                ctx.Students.Add(student);
                ctx.SaveChanges();
            }
        }
    }
}
