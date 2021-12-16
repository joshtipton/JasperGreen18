using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JasperGreen18.Models
{
    public class Crew
    {
        public int CrewID { get; set; }

        [Required(ErrorMessage = "The crew must have a foreman. Please select one.")]
        public int CrewForemanID { get; set; }
        public Employee CrewForeman { get; set; }

        [Required(ErrorMessage = "The crew must have a first member. Please select one.")]
        public int CrewMember1ID { get; set; }
        public Employee CrewMember1 { get; set; }

        [Required(ErrorMessage = "The crew must have a second member. Please select one.")]
        public int CrewMember2ID { get; set; }
        public Employee CrewMember2 { get; set; }

    }
}
