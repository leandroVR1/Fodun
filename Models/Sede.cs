using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fodun.Models
{
    public class Sede
    {
        public int SedeId { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int CapacidadTotal { get; set; }
        public string Ubicacion { get; set; }
        public string Descripcion { get; set; }
        
        
    }
}