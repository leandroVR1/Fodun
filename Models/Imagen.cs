namespace Fodun.Models{
    
    public class Imagen
{
    public int ImagenId { get; set; }
    public string Url { get; set; }
    public int SedeId { get; set; }

    public Sede Sede { get; set; }
}

}