using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    [Table("Usuario")]
    public class UsuarioModel
    {

        [Required]
        [Display(Name = "Usuário")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }

    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
