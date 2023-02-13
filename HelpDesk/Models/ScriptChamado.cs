using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class ScriptChamado
    {
        [Key]
        [Display(Name = "idScriptChamado")]
        public int IdScriptChamado { get; set; }

        [Required]
        [Display(Name = "desScript")]
        public string DesScript { get; set; }

        [Required]
        [Display(Name = "idSubGategoria")]
        public string IdSubGategoria { get; set; }
    }
}
