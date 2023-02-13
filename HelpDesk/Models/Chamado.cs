using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class Chamado
    {
        [Key]
        [Display(Name = "IdChamado")]
        public int IdChamado { get; set; }
        [Required]
        [Display(Name = "Assunto")]
        public string Assunto { get; set; }
        [Required]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }
        [Required]
        [Display(Name = "DataInicio")]
        public string DataInicio { get; set; }
        [Required]
        [Display(Name = "IdCliente")]
        public int IdCliente { get; set; }
        [Required]
        [Display(Name = "NmOperador")]
        public string NmOperador { get; set; }
        [Required]
        [Display(Name = "IdUsuarioResponsavel")]
        public string IdUsuarioResponsavel { get; set; }
        [Required]
        [Display(Name = "EstadoChamado")]
        public string EstadoChamado { get; set; }
        [Required]
        [Display(Name = "CentroCusto")]
        public string CentroCusto { get; set; }
        [Required]
        [Display(Name = "TipoChamado")]
        public string TipoChamado { get; set; }
        [Required]
        [Display(Name = "CategoriaServico")]
        public string CategoriaServico { get; set; }
        [Required]
        [Display(Name = "SubCategoriaServico")]
        public string SubCategoriaServico { get; set; }
        [Required]
        [Display(Name = "NmNivelOperacional")]
        public string NmNivelOperacional { get; set; }
        
    }
}
