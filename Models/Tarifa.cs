using System;

namespace Fodun.Models
{
public class Tarifa
{
    public int TarifaId { get; set; }
    public int SedeId { get; set; }
    public int AlojamientoId { get; set; } 
    public string Temporada { get; set; }
    public string TipoTemporada { get; set; } 
    public int NumeroPersonas { get; set; }
    
    public double TarifaPorPersona { get; set; }
    
    public double TarifaPorNoche { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }

    public Sede Sede { get; set; }
    public Alojamiento Alojamiento { get; set; }
}

}
