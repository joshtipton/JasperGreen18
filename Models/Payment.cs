using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace JasperGreen18.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int CustomerID { get; set; }
        public Customer CurrentCustomer { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public decimal PaymentAmount { get; set; }

        public ICollection<ProvideService> PaymentServices { get; set; }
    }
}
