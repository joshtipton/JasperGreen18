using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JasperGreen18.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        public string CustomerFirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        public string CustomerLastName { get; set; }

        [Required(ErrorMessage = "Please enter a valid address.")]
        public string BillingAddress { get; set; }

        [Required(ErrorMessage = "Please enter a valid city.")]
        public string BillingCity { get; set; }

        [Required(ErrorMessage = "Please select a valid state.")]
        public string BillingState { get; set; }

        [Required(ErrorMessage = "Zip code is required.")]
        [StringLength(10, MinimumLength = 5)]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Zip code must be in format: 12345 or 12345-6789")]
        public string BillingZip { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone number must be in (999)-999-9999 format.")]
        public string CustomerPhone { get; set; }

        public string CustomerFullName => CustomerFirstName + " " + CustomerLastName;

        public ICollection<Property> CustomerProperties { get; set; }

        public ICollection<Payment> CustomerPayments { get; set; }

        public ICollection<ProvideService> CustomerServices { get; set; }

    }
}
