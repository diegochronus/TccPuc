using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class Funcao
    {
        [Key]
        [Display(Name = "idFuncao")]
        public int idFuncao { get; set; }

        [Required]
        [Display(Name = "nmFuncao")]
        public string nmFuncao { get; set; }
    }
}
