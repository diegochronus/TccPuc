using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class NivelOperacional
    {
        [Key]
        [Display(Name = "idNivelOperacional")]
        public int IdNivelOperacional { get; set; }

        [Required]
        [Display(Name = "nmNivelOperacional")]
        public string NmNivelOperacional { get; set; }
    }
}
