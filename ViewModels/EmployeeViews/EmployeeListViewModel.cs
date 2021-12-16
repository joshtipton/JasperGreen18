using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace JasperGreen18.Models
{
    public class EmployeeListViewModel
    {
        public List<Employee> Employees { get; set; }
        public string Action { get; set; }
    }
}
