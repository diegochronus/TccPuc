using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class CentroCusto
    {
        [Key]
        [Display(Name = "idCentroCusto")]
        public int idCentroCusto { get; set; }

        [Required]
        [Display(Name = "nmCentroCusto")]
        public string nmCentroCusto { get; set; }
    }
}
