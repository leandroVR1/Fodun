using System;
using System.ComponentModel.DataAnnotations;

namespace Fodun.Models
{
   public class Disponibilidad
{
    [Key]
    public int DisponibilidadId { get; set; }
    public int AlojamientoId { get; set; }
    
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public bool Disponible { get; set; }

    public Alojamiento Alojamiento { get; set; }
}

}
