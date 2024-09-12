using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fodun.Data;
using Fodun.Models;
using Microsoft.EntityFrameworkCore;

namespace Fodun.Services
{
    public class SedeService : ISedeService
    {
       
        private readonly ApplicationDbContext _dbContext;

        public SedeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Sede>> GetSedes()
        {
            // Retrieve sedes from database or repository
            var sedes = await _dbContext.Sedes.ToListAsync();

            return sedes;
        }
    }
}