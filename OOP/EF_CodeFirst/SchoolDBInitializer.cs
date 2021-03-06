﻿using System.Collections.Generic;
using System.Data.Entity;

namespace OOP
{
    public class SchoolDBInitializer : DropCreateDatabaseAlways<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            IList<Grade> grades = new List<Grade>();

            grades.Add(new Grade() { GradeName = "Grade 1", Section = "A" });
            grades.Add(new Grade() { GradeName = "Grade 1", Section = "B" });
            grades.Add(new Grade() { GradeName = "Grade 1", Section = "C" });
            grades.Add(new Grade() { GradeName = "Grade 2", Section = "A" });
            grades.Add(new Grade() { GradeName = "Grade 3", Section = "A" });

            context.Grades.AddRange(grades);

            IList<Student> stds = new List<Student>();

            stds.Add(new Student() {  StudentName = "StudentName 1", GradeId = 1 });
            stds.Add(new Student() { StudentName = "StudentName 1", GradeId = 1 });
            stds.Add(new Student() { StudentName = "StudentName 1", GradeId = 2 });
            stds.Add(new Student() { StudentName = "StudentName 1", GradeId = 2 });


            context.Students.AddRange(stds);




            base.Seed(context);
        }
    }
}