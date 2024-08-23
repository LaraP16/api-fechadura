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
        public int Idsala { get; set; }

        [Column("sala")]
        public string? Nome_Usuario { get; set;}
        [Column("sala")]
        public string? Nome { get; set;}

        [Column("status")]
        public string? Status { get; set; }

        [Column("horario")]
        public string? Horario { get; set;}

    }
}