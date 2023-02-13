using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.Models;
using System.Security.Cryptography;
using System.Text;

namespace HelpDesk.Models
{
    public class HelpDeskContext : DbContext
    {
        public HelpDeskContext(DbContextOptions<HelpDeskContext> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<HelpDesk.Models.Chamado> Chamado { get; set; }
        public static Usuario GetUsuarioPadrao()
        {
            return new Usuario()
            {
                Login = "admin",
                Senha = GerarHash("Of1c1n@21"),
                Nome = "Administrador",
                Email = ""
            };
        }
        public static string GerarHash(string input)
        {
            MD5 md5Hash = MD5.Create();

            // Converter a String para array de bytes, que é como a biblioteca trabalha.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Cria-se um StringBuilder para recompôr a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop para formatar cada byte como uma String em hexadecimal
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
        public DbSet<HelpDesk.Models.Tipo> Tipo { get; set; }
        public DbSet<HelpDesk.Models.CentroCusto> CentroCusto { get; set; }
        public DbSet<HelpDesk.Models.EstadoChamadocs> EstadoChamadocs { get; set; }
        public DbSet<HelpDesk.Models.Funcao> Funcao { get; set; }
        public DbSet<HelpDesk.Models.HistoricoChamado> HistoricoChamado { get; set; }
        public DbSet<HelpDesk.Models.NivelOperacional> NivelOperacional { get; set; }
        public DbSet<HelpDesk.Models.ScriptChamado> ScriptChamado { get; set; }
        public DbSet<HelpDesk.Models.Setores> Setores { get; set; }
        public DbSet<HelpDesk.Models.Tecnico> Tecnico { get; set; }
        public DbSet<HelpDesk.Models.usuarioCentroCusto> usuarioCentroCusto { get; set; }

    }
}

