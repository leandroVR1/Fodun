using System.Threading.Tasks;
using Fodun.Data;
using Fodun.Models;
using Microsoft.EntityFrameworkCore;
using Fodun.Models.Dtos;
using Microsoft.AspNetCore.Identity;



namespace Fodun.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserService(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> ValidateUser(string nroDocumento, string clave)
        {
            // Busca el usuario en la base de datos por NroDocumento
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NroDocumento == nroDocumento);

            if (usuario == null)
            {
                return false; // El usuario no existe
            }

            // Verifica la clave (esto asume que usas la clave en texto plano, lo cual no es recomendable)
            return usuario.Clave == clave;
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
