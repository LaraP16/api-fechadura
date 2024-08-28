using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_fechadura.Models
{
    public class Sala
    {
        [Column("idsala")]
        public int IdSala { get; set; }

        [Column("nome")]
        public string? Nome { get; set;}

        [Column("usuario_idusuario")]
        public int? IdUsuario { get; set;}

    }
}