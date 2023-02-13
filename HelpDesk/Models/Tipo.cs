using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class Tipo
    {
        [Key]
        [Display(Name = "idTipo")]
        public int IdTipo { get; set; }

        [Required]
        [Display(Name = "nmTipo")]
        public string NmTipo { get; set; }
    }
}
