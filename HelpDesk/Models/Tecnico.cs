using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class Tecnico
    {
        [Key]
        [Display(Name = "idTecnico")]
        public int IdTecnico { get; set; }

        [Required]
        [Display(Name = "idUsuario")]
        public string IdUsuario { get; set; }

        [Required]
        [Display(Name = "idSetor")]
        public string IdSetor { get; set; }

        [Required]
        [Display(Name = "idNivelOperacional")]
        public string IdNivelOperacional { get; set; }
    }
}
