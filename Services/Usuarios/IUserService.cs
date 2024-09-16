using System.Threading.Tasks;
using Fodun.Models.Dtos;

namespace Fodun.Services
{
    public interface IUserService
    {
        Task<bool> ValidateUser(string email, string password);
        Task<bool> RegisterUser(RegistroUsuario registroDto);
        Task<bool> RecuperarClave(string emailOrDocumento);
    }
}
