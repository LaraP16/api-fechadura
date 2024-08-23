using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_eventos.Models
{
    public class Usuario
    {
        [Column("idusuario")]
        public int IdUsuario { get; set; }

        [Column("nome_completo")]
        public string? NomeCompleto { get; set;}

        [Column("nif")]
        public string? Email { get; set; }

        [Column("senha")]
        public string? Senha { get; set;}

    }
}