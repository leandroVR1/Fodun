using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fodun.Models
{
     public class ReservaViewModel
    {
        public int AlojamientoId { get; set; }
        
        [Required(ErrorMessage = "La fecha de inicio es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }
        
        [Required(ErrorMessage = "La fecha de fin es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }
        
        [Required(ErrorMessage = "El número de personas es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El número de personas debe ser mayor a 0")]
        public int NumeroPersonas { get; set; }
        
        public decimal TotalPagar { get; set; }
    }
}