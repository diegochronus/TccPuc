using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class usuarioCentroCusto
    {
        [Key]
        [Display(Name = "idUsuario")]
        public int idUsuario { get; set; }

        [Required]
        [Display(Name = "idCentroCusto")]
        public string idCentroCusto { get; set; }
    }
}
