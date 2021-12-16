using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JasperGreen18.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Your name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a valid email address.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Your message cannot be empty.")]
        public string Message { get; set; }
    }
}
