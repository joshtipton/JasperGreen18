using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace JasperGreen18.Models
{
    public class EmployeeViewModel
    {
        public Employee CurrentEmployee { get; set; }
        public string Action { get; set; }
    }
}
