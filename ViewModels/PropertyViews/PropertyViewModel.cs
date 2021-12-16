using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace JasperGreen18.Models
{
    public class PropertyViewModel
    {
        public Property CurrentProperty { get; set; }
        public List<Customer> GetCustomers { get; set; }
        public string Action { get; set; }
    }
}
