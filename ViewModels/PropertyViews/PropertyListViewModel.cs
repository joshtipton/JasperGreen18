using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace JasperGreen18.Models
{
    public class PropertyListViewModel
    {
        public List<Property> Properties { get; set; }
        public string Action { get; set; }
    }
}
