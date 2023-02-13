using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class Setores
    {
        [Key]
        [Display(Name = "idSetor")]
        public int IdSetor { get; set; }

        [Required]
        [Display(Name = "nmSetor")]
        public string NmSetor { get; set; }
    }
}
