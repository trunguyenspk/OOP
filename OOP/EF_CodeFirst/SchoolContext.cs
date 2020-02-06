using System.Data.Entity;

namespace OOP
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("SchoolDBTest")
        {
            Database.SetInitializer(new SchoolDBInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Adds configurations for Student from separate class
            //StudentConfigurations is derived from EntityTypeConfiguration<T>

            modelBuilder.Configurations.Add(new StudentConfigurations());

            modelBuilder.Entity<Teacher>().ToTable("Teacher");

            modelBuilder.Entity<Teacher>().MapToStoredProcedures();

            modelBuilder.Entity<Car>().ToTable("Car");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}