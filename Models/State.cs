using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JasperGreen18.Models
{
    public class State
    {
        [Required]
        public string StateID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
