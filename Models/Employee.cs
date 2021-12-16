using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JasperGreen18.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        public string EmployeeFirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        public string EmployeeLastName { get; set; }

        [Required(ErrorMessage = "An employee must have a social security number.")]
        [StringLength(maximumLength: 9, MinimumLength = 9, ErrorMessage = "A social security # must have 9 digits.")]
        public string SSN { get; set; }

        [Required(ErrorMessage = "Please enter a job title.")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Please enter a hire date.")]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Please enter an hourly pay rate.")]
        public decimal HourlyRate { get; set; }

        public string EmployeeFullName => EmployeeFirstName + " " + EmployeeLastName;

        public int CrewForemanID { get; set; }
        public int CrewMember1ID { get; set; }
        public int CrewMember2ID { get; set; }

        public ICollection<Crew> CrewsF { get; set; }
        public ICollection<Crew> Crews1 { get; set; }
        public ICollection<Crew> Crews2 { get; set; }
    }
}
