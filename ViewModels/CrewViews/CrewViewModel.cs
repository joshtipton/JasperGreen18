using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace JasperGreen18.Models
{
    public class CrewViewModel
    {
        public Crew CurrentCrew { get; set; }
        public List<Employee> GetEmployees { get; set; }
        public string Action { get; set; }

        // Validation Strings
        public string DistinctForeman { get; set; }
        public string DistinctMember1 { get; set; }
        public string DistinctMember2 { get; set; }
    }
}
