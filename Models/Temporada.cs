using System;

namespace Fodun.Models
{
public class Temporada
{
    public int TemporadaId { get; set; }
    public string Nombre { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public bool EsEspecial { get; set; }
}

}
