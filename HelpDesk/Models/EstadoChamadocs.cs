using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class EstadoChamadocs
    {
        [Key]
        [Display(Name = "idEstadoChamado")]
        public int idEstadoChamado { get; set; }

        [Required]
        [Display(Name = "nmEstadoChamado")]
        public string nmEstadoChamado { get; set; }
    }
}
