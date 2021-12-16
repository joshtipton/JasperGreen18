using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JasperGreen18.Models
{
    public class ProvideService
    {
        [Key]
        public int ServiceID { get; set; }

        public int CrewID { get; set; }
        public Crew CurrentCrew { get; set; }

        public int CustomerID { get; set; }
        public Customer CurrentCustomer { get; set; }

        public int PropertyID { get; set; }
        public Property CurrentProperty { get; set;}

        public int PaymentID { get; set; }
        public Payment CurrentPayment { get; set; }

        [Required]
        public DateTime ServiceDate { get; set; }

        public decimal ServiceFee { get; set; }
    }
}
