using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace JasperGreen18.Models
{
    public class Property
    {
        public int PropertyID { get; set; } // primary key

        [Required(ErrorMessage = "Select the customer that owns this property.")]
        public int CustomerID { get; set; } // foreign-key
        public Customer PropertyOwner { get; set; }

        [Required(ErrorMessage = "Property Address is a required field.")]
        public string PropertyAddress { get; set; }

        [Required(ErrorMessage = "Property City is a required field.")]
        public string PropertyCity { get; set; }

        [Required(ErrorMessage = "Property State is a required field.")]
        public string PropertyState { get; set; }

        [Required(ErrorMessage = "Property Zip Code is a required field.")]
        public string PropertyZip { get; set; }

        [Required(ErrorMessage = "Service Fee is a required field.")]
        public decimal ServiceFee { get; set; }

        public ICollection<ProvideService> PropertyServices { get; set;}
    }
}
