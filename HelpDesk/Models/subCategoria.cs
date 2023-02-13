using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class subCategoria
    {
        [Key]
        [Display(Name = "idSubCategoria")]
        public int IdSubCategoria { get; set; }

        [Required]
        [Display(Name = "nmSubCategoria")]
        public string NmSubCategoria { get; set; }

        [Required]
        [Display(Name = "idCategoria")]
        public string IdCategoria { get; set; }



    }
}
