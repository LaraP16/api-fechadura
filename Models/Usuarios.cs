using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_fechadura.Models
{
    public class Usuario
    {
        [Column("idusuario")]
        public int IdUsuario { get; set; }

        [Column("nome")]
        public string? Nome { get; set;}

        [Column("nif")]
        public int? Nif { get; set; }

        [Column("senha")]
        public string? Senha { get; set;}

    }
}