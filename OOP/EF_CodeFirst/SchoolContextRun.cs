using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP.EF_CodeFirst
{
    public static class SchoolContextRun
    {
        public static void Run()
        {
            using (var ctx = new SchoolContext())
            {
                //var grades = ctx.Grades.ToList();
                
                var grades = ctx.Grades.Include("Students").ToList();

                Grade firstGr = grades[0];

                //Loads Student address for particular Student only (seperate SQL query)
                //var add = firstGr.Students;

            }
        }
    }
}
