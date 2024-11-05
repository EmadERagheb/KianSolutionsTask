using Data.DbContexts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace ProductService.Seeding
{
    public static class ApplicationDbContextSeeding
    {
        public static async Task Seed(ApplicationDbContext context)
        {
            await SeedEmployee(context);
        }
        private static async Task SeedEmployee(ApplicationDbContext context)
        {
            if (await context.Employees.AnyAsync()) return;
            List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                FirstName = "John",
                LastName = "Smith",
                UserName = "jsmith",
                Active = true
            },
            new Employee
            {
                FirstName = "Maria",
                LastName = "Garcia",
                UserName = "mgarcia",
                Active = true
            },
            new Employee
            {
                FirstName = "David",
                LastName = "Johnson",
                UserName = "djohnson",
                Active = false
            },
            new Employee
            {
                FirstName = "Sarah",
                LastName = "Williams",
                UserName = "swilliams",
                Active = true
            },
            new Employee
            {
                FirstName = "Michael",
                LastName = "Brown",
                UserName = "mbrown",
                Active = true
            },
            new Employee
            {
                FirstName = "Jennifer",
                LastName = "Davis",
                UserName = "jdavis",
                Active = true
            },
            new Employee
            {
                FirstName = "Robert",
                LastName = "Miller",
                UserName = "rmiller",
                Active = false
            },
            new Employee
            {
                FirstName = "Lisa",
                LastName = "Wilson",
                UserName = "lwilson",
                Active = true
            },
            new Employee
            {
                FirstName = "James",
                LastName = "Anderson",
                UserName = "janderson",
                Active = true
            },
            new Employee
            {
                FirstName = "Emily",
                LastName = "Taylor",
                UserName = "etaylor",
                Active = true
            },
              new Employee
            {
                FirstName = "Daniel",
                LastName = "Martinez",
                UserName = "dmartinez",
                Active = true
            },
            new Employee
            {
                FirstName = "Patricia",
                LastName = "Thompson",
                UserName = "pthompson",
                Active = true
            },
            new Employee
            {
                FirstName = "Kevin",
                LastName = "Lee",
                UserName = "klee",
                Active = false
            },
            new Employee
            {
                FirstName = "Sandra",
                LastName = "White",
                UserName = "swhite",
                Active = true
            },
            new Employee
            {
                FirstName = "Christopher",
                LastName = "Rodriguez",
                UserName = "crodriguez",
                Active = true
            },
            new Employee
            {
                FirstName = "Michelle",
                LastName = "Clark",
                UserName = "mclark",
                Active = false
            },
            new Employee
            {
                FirstName = "Thomas",
                LastName = "Walker",
                UserName = "twalker",
                Active = true
            },
            new Employee
            {
                FirstName = "Nancy",
                LastName = "Hall",
                UserName = "nhall",
                Active = true
            },
            new Employee
            {
                FirstName = "Richard",
                LastName = "Young",
                UserName = "ryoung",
                Active = true
            },
            new Employee
            {
                FirstName = "Laura",
                LastName = "King",
                UserName = "lking",
                Active = true
            }

        };
            await context.Employees.AddRangeAsync(employees);
            await context.SaveChangesAsync();

        }
    }
}

