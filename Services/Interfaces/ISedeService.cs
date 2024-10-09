using System.Collections.Generic;
using Fodun.Models;

namespace Fodun.Services.Interfaces
{
    public interface ISedeService
    {
        IEnumerable<Sede> GetSedesRecreativas();
        IEnumerable<Sede> GetApartamentos();
        Sede GetSedeById(int id);
    }
}