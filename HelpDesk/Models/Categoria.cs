using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class Categoria
    {
        [Key]
        [Display(Name = "idCategoria")]
        public int IdCategoria { get; set; }

        [Required]
        [Display(Name = "nmCategoria")]
        public string NmCategoria { get; set; }
    }

}
