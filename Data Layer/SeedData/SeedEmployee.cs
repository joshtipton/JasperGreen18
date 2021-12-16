using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace JasperGreen18.Models
{
    internal class SeedEmployee : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity.HasData(
              new Employee
              {
                  EmployeeID = 1,
                  EmployeeFirstName = "Josh",
                  EmployeeLastName = "Tipton",
                  HireDate = DateTime.Parse("2020-05-17"),
                  JobTitle = "Foreman",
                  HourlyRate = 9.31M,
                  SSN = "827937161"
              },
              new Employee
              {
                  EmployeeID = 2,
                  EmployeeFirstName = "James",
                  EmployeeLastName = "Smith",
                  HireDate = DateTime.Parse("2020-03-16"),
                  JobTitle = "Foreman",
                  HourlyRate = 10.11M,
                  SSN = "819267345"
              },
              new Employee
              {
                  EmployeeID = 3,
                  EmployeeFirstName = "Adam",
                  EmployeeLastName = "Stevens",
                  HireDate = DateTime.Parse("2020-02-08"),
                  JobTitle = "Basic Crew Member",
                  HourlyRate = 10.00M,
                  SSN = "191675544"
              },
              new Employee
              {
                  EmployeeID = 4,
                  EmployeeFirstName = "Peter",
                  EmployeeLastName = "Parker",
                  HireDate = DateTime.Parse("2020-07-23"),
                  JobTitle = "Basic Crew Member",
                  HourlyRate = 10.00M,
                  SSN = "907665312"
              },
              new Employee
              {
                  EmployeeID = 5,
                  EmployeeFirstName = "Tony",
                  EmployeeLastName = "Stark",
                  HireDate = DateTime.Parse("2020-01-14"),
                  JobTitle = "Basic Crew Member",
                  HourlyRate = 11.15M,
                  SSN = "767889421"
              },
              new Employee
              {
                  EmployeeID = 6,
                  EmployeeFirstName = "Clint",
                  EmployeeLastName = "Barton",
                  HireDate = DateTime.Parse("2020-04-23"),
                  JobTitle = "Foreman",
                  HourlyRate = 10.50M,
                  SSN = "112772445"
              },
              new Employee
              {
                  EmployeeID = 7,
                  EmployeeFirstName = "Chadwick",
                  EmployeeLastName = "Boseman",
                  HireDate = DateTime.Parse("2020-06-11"),
                  JobTitle = "Foreman",
                  HourlyRate = 11.23M,
                  SSN = "322567256"
              },
              new Employee
              {
                  EmployeeID = 8,
                  EmployeeFirstName = "Jonah",
                  EmployeeLastName = "Hill",
                  HireDate = DateTime.Parse("2020-04-03"),
                  JobTitle = "Foreman",
                  HourlyRate = 10.00M,
                  SSN = "829182197"
              },
              new Employee
              {
                  EmployeeID = 9,
                  EmployeeFirstName = "Juan",
                  EmployeeLastName = "Rodriguez",
                  HireDate = DateTime.Parse("2020-02-09"),
                  JobTitle = "Foreman",
                  HourlyRate = 10.43M,
                  SSN = "881904418"
              },
              new Employee
              {
                  EmployeeID = 10,
                  EmployeeFirstName = "Alex",
                  EmployeeLastName = "Escobar",
                  HireDate = DateTime.Parse("2020-08-24"),
                  JobTitle = "Foreman",
                  HourlyRate = 12.19M,
                  SSN = "221339153"
              },
              new Employee
              {
                  EmployeeID = 11,
                  EmployeeFirstName = "Tanner",
                  EmployeeLastName = "Ray",
                  HireDate = DateTime.Parse("2020-03-15"),
                  JobTitle = "Foreman",
                  HourlyRate = 12.31M,
                  SSN = "705628112"
              },
              new Employee
              {
                  EmployeeID = 12,
                  EmployeeFirstName = "Michael",
                  EmployeeLastName = "Jackson",
                  HireDate = DateTime.Parse("2020-07-22"),
                  JobTitle = "Foreman",
                  HourlyRate = 11.46M,
                  SSN = "808976663"
              },
              new Employee
              {
                  EmployeeID = 13,
                  EmployeeFirstName = "Stephen",
                  EmployeeLastName = "Hamster",
                  HireDate = DateTime.Parse("2020-09-12"),
                  JobTitle = "Foreman",
                  HourlyRate = 9.49M,
                  SSN = "623112013"
              },
              new Employee
              {
                  EmployeeID = 14,
                  EmployeeFirstName = "Jack",
                  EmployeeLastName = "Reacher",
                  HireDate = DateTime.Parse("2020-03-17"),
                  JobTitle = "Foreman",
                  HourlyRate = 10.05M,
                  SSN = "516620901"
              },
              new Employee
              {
                  EmployeeID = 15,
                  EmployeeFirstName = "Bruce",
                  EmployeeLastName = "Banner",
                  HireDate = DateTime.Parse("2020-01-25"),
                  JobTitle = "Foreman",
                  HourlyRate = 11.07M,
                  SSN = "716809112"
              });
        }
    }
}