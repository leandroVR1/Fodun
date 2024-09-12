using System.ComponentModel.DataAnnotations;

namespace Fodun.Models{

    public class Usuario{
       
         public int Id { get; set; }

        [Required(ErrorMessage = "La Identificación es obligatoria" )]
        [RegularExpression(@"^\d+$", ErrorMessage = "La Identificación debe contener solo números.")]
        public string NroDocumento { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Celular { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo Electrónico")]
        [RegularExpression(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$", ErrorMessage = "El campo Correo electrónico no es una dirección de correo electrónico válida.")]
        [Required(ErrorMessage = "El Email es obligatorio")]
        public string Email { get; set; }
        public string Departamento { get; set; }
        public string Municipio {get; set; }
        public string Barrio { get; set; }
        public string Direccion { get; set; }
        public string Telefono {get; set; }
        public string Clave { get; set; }
        public string PreguntaClave {get; set; }
        public string RespuestaClave {get; set; }
         public ICollection<Reserva> Reservas { get; set; }

    }
}
