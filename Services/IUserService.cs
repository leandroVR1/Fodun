using System.Threading.Tasks;
using Fodun.Models.Dtos;

namespace Fodun.Services
{
    public interface IUserService
    {
        Task<bool> ValidateUser(string nroDocumento, string clave);
        Task<bool> RegisterUser(RegistroUsuario registroDto);
        
    }
}
