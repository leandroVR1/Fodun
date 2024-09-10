using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fodun.Models
{
    public class Disponivilidad
    {
        [Key]
        public int DisponibilidadId { get; set; }
        public int AlojamientoId { get; set; }
        public DateTime Fecha { get; set; }
        public bool Disponible { get; set; }
        public Alojamiento Alojamiento { get; set; }

        
    }
}