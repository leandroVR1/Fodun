using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fodun.Services
{
    public interface IAuthService
    {

        Task<bool> ValidateUser(string nroDocumento, string clave);
        
        
    }
}