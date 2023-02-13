using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class HistoricoChamado
    {
        [Key]
        [Display(Name = "idHistorico")]
        public int IdHistorico { get; set; }

        [Required]
        [Display(Name = "descHistorico")]
        public string DescHistorico { get; set; }

        [Required]
        [Display(Name = "dataHistorico")]
        public string DataHistorico { get; set; }

        [Required]
        [Display(Name = "idChamado")]
        public string IdChamado { get; set; }

        [Required]
        [Display(Name = "idUsuario")]
        public string IdUsuario { get; set; }
    }
}
