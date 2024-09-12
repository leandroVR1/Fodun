using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Fodun.Models.Dtos;

namespace Fodun.Services
{
    public interface IAuthService
    {
        Task<bool> ValidateUser(string nroDocumento, string clave);
        Task<bool> RegisterUser(RegistroUsuario registerDto);
        Task<bool> RecuperarClave(string emailOrDocumento);
    }

}