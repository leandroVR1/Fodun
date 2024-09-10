using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fodun.Models
{
    public class Tarifa
    {
        public int TarifaId { get; set; }
        public int SedeId { get; set; }
        public string Temporada { get; set; }
        public int NumeroPersonas { get; set; }
        public Double TarifaPorNoche { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Sede Sede { get; set; }

        
    }
}