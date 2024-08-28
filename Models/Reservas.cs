using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_fechadura.Models
{
    public class Reserva
    {
        [Column("idreserva")]
        public int IdReserva { get; set; }

        [Column("sala")]
        public int? IdSala { get; set;}

        [Column("idusuario")]
        public int? IdUsuario { get; set;}


    }
}