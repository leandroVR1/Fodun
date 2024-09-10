
using Fodun.Models;
using Microsoft.EntityFrameworkCore;
using Fodun.Data;


namespace Fodun.Services{
public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;

    public AuthService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ValidateUser(string nroDocumento, string clave)
    {
        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.NroDocumento == nroDocumento && u.Clave == clave);

        return usuario != null;
    }
}
}