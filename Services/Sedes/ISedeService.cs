using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fodun.Models;

namespace Fodun.Services
{
    public interface ISedeService
    {
        Task<IEnumerable<Sede>> GetSedes();
    }
}