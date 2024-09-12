using System.Threading.Tasks;
using Fodun.Data;
using Fodun.Models;
using Microsoft.EntityFrameworkCore;
using Fodun.Models.Dtos;


namespace Fodun.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ValidateUser(string nroDocumento, string clave)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NroDocumento == nroDocumento && u.Clave == clave);

            return usuario != null;
        }

        public async Task<bool> RegisterUser(RegistroUsuario registroDto)
        {
            var usuario = new Usuario
            {
               NroDocumento = registroDto.NroDocumento,
                Nombre = registroDto.Nombre,
                FechaNacimiento = registroDto.FechaNacimiento,
                Celular = registroDto.Celular,
                Email = registroDto.Email,
                Departamento = registroDto.Departamento,
                Municipio = registroDto.Municipio,
                Barrio = registroDto.Barrio,
                Direccion = registroDto.Direccion,
                Telefono = registroDto.Telefono,
                Clave = registroDto.Clave,
                PreguntaClave = registroDto.PreguntaClave,
                RespuestaClave = registroDto.RespuestaClave
              
            };

            _context.Usuarios.Add(usuario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RecuperarClave(string nroDocumento)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NroDocumento == nroDocumento);

            if (usuario == null) return false;

          
            return true;
        }
    }
}
