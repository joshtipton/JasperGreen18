using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace JasperGreen18.Models
{
    public class CustomerViewModel
    {
        public Customer CurrentCustomer { get; set; }
        public string Action { get; set; }
        public List<State> GetStates { get; set; }
    }
}
