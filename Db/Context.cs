using Microsoft.EntityFrameworkCore;
using ProjectTracker.Models;

namespace ProjectTracker.Db
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the DbContext to use an in-memory database
            optionsBuilder.UseInMemoryDatabase("ProjectTrackerDb");
        }

        public DbSet<Employee> Employees { get; set; }

        public static class DbSeeder
        {
            public static void SeedData(Context context)
            {
                var employees = new List<Employee>
                {
                    new Employee
                    {
                        Name = "Ankur",
                        Company = "IBM",
                        Project = "Payroll",
                        Role = "Software Engineer"
                    },
                    new Employee
                    {
                        Name = "Akash",
                        Company = "IBM",
                        Project = "Chat Bot",
                        Role = "Software Engineer"
                    },
                    new Employee
                    {
                        Name = "Priya",
                        Company = "HP",
                        Project = "VR Gaming",
                        Role = "Project Manager"
                    },
                    new Employee
                    {
                        Name = "Asha",
                        Company = "Microsoft",
                        Project = "Payroll",
                        Role = "Solution Architect"
                    },
                    new Employee
                    {
                        Name = "Nandini",
                        Company = "HP",
                        Project = "Payroll",
                        Role = "Software Engineer"
                    },
                    new Employee
                    {
                        Name = "Piyush",
                        Company = "Microsoft",
                        Project = "Payroll",
                        Role = "Delivery Manager"
                    },
                    new Employee
                    {
                        Name = "Ankur",
                        Company = "HP",
                        Project = "Chat Bot",
                        Role = "Lead Engineer"
                    },
                    new Employee
                    {
                        Name = "Akash",
                        Company = "HP",
                        Project = "VR Gaming",
                        Role = "Software Engineer"
                    },
                    new Employee
                    {
                        Name = "Priya",
                        Company = "IBM",
                        Project = "Payroll",
                        Role = "Solution Architect"
                    },
                    new Employee
                    {
                        Name = "Asha",
                        Company = "HP",
                        Project = "Chat Bot",
                        Role = "Project Manager"
                    },
                    new Employee
                    {
                        Name = "Nandini",
                        Company = "IBM",
                        Project = "VR Gaming",
                        Role = "Lead Engineer"
                    },
                    new Employee
                    {
                        Name = "Piyush",
                        Company = "IBM",
                        Project = "VR Gaming",
                        Role = "Delivery Manager"
                    }
                };

                // Add data to the DbContext
                foreach (var employee in employees)
                {
                    context.Employees.Add(employee);
                }

                // Save changes to the in-memory database
                context.SaveChanges();
            }
        }
    }
}
